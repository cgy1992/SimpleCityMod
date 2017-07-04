using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NLua;
using System.IO;
using Newtonsoft.Json;

namespace Andras.ModTools
{
    public class ModController
    {
        public static List<Mod> mods;
        public static Dictionary<string, ModController> modContollers;

        public static void LoadMods()
        {
            try
            {
                Dictionary<string, ModController> returnValue = new Dictionary<string, ModController>();

                mods = JsonConvert.DeserializeObject<List<Mod>>(File.ReadAllText("Scripts/scripts.modinfo"));

                for (int i = 0; i < mods.Count; i++)
                {
                    if (mods[i].isActive)
                        returnValue.Add(mods[i].fileName, new ModController(mods[i]));
                }

                modContollers = returnValue;
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error: " + e.Message);
            }
        }
        public static Mod LoadMod(string _filePath)
        {
            return new Mod(_filePath, true);
        }
        public static Mod GetByName(string _filename)
        {
            if (mods == null || mods.Count == 0)
                LoadMods();

            for (int i = 0; i < mods.Count; i++)
            {
                if (mods[i].fileName == _filename)
                    return mods[i];
            }
            return null;
        }

        public Lua lua = new Lua();

        Mod mod;

        public ModController(Mod _mod)
        {
            mod = _mod;
            CreateModContoller();

            if (mods == null || mods.Count == 0)
                LoadMods();
        }

        public ModController()
        {

        }

        public ModController(string _fileName)
        {
            mod = LoadMod(_fileName);
            CreateModContoller();

            if (mods == null || mods.Count == 0)
                LoadMods();
        }

        static public List<BuildItem> LoadBuildItems()
        {
            List<BuildItem> temp = new List<BuildItem>();

            if (mods == null || mods.Count == 0)
                LoadMods();

            foreach (var item in modContollers.Values)
            {
                BuildItem bi = (BuildItem)item.lua["buildItem"];

                if (bi.isActive == true)
                    temp.Add(bi);
            }

            return temp;
        }

        void CreateModContoller()
        {
            lua.LoadCLRPackage();
            lua["GameManager"] = GameObject.Find("_GameManager").GetComponent<GameManager>();
            lua["this"] = this;
            lua["buildItem"] = new BuildItem(mod.fileName);

            string _source = File.ReadAllText("Scripts/" + mod.fileName + ".lua");

            try
            {
                lua.DoString(_source);
            }
            catch (NLua.Exceptions.LuaException e)
            {
                Debug.LogError(e.Message);
                Console.LogError(e.Message);
            }
        }

        public void LoadModels(string _path)
        {
            Debug.Log(_path);
        }

        public System.Object[] Call(string function, params System.Object[] args)
        {
            System.Object[] result = new System.Object[0];
            if (lua == null) return result;
            LuaFunction lf = lua.GetFunction(function);
            if (lf == null) return result;
            try
            {
                if (args != null)
                {
                    result = lf.Call(args);
                }
                else
                {
                    result = lf.Call();
                }
            }
            catch (NLua.Exceptions.LuaException e)
            {
                Debug.LogError(e.Message);
                throw e;
            }
            return result;
        }
    }
}