using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Andras.ModTools;
using System;
using System.IO;

public class BuildItem
{
    public string DisplayName { get; set; }
    public string FileName { get; set; }
    public Sprite DisplayImage { get; set; }

    public int BuildCost { get; set; }
    public int SellCost { get; set; }

    public GameObject Model { get; set; }
    public Vector3 Scale { get; set; }

    public bool isActive = false;

    public BuildItem(string _fileName = "")
    {
        FileName = _fileName;
    }

    public void Init()
    {
        isActive = true;

        Debug.Log(this + " is initialized");
    }

    public void OnNextRound()
    {
        ModManager.OnNextRound();

        Debug.Log(Scale);
    }

    public void LoadDisplayImage(string path)
    {
        try
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(File.ReadAllBytes(path));
            DisplayImage = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}
