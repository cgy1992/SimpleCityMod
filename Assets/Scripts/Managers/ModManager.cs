using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Andras.ModTools;

public class ModManager : MonoBehaviour
{

    static Dictionary<string,ModController> mc;

    void Start()
    {
        ModController.LoadMods();
        mc = ModController.modContollers;

        foreach (var item in mc.Values)
        {
            item.Call("OnUpdate");
        }
    }
	
	void Update ()
    {
        foreach (var item in mc.Values)
        {
            item.Call("OnUpdate");
        }
	}

    public static void OnNextRound()
    {
        foreach (var item in mc.Values)
        {
            item.Call("OnNextRound");
        }
    }
}
