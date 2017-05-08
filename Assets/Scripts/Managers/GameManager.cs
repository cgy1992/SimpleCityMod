using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Andras.ModTools;

public class GameManager : MonoBehaviour {

    public static int population;
    public static int money;

    public static bool hasChanged = false;

    public static List<BuildItem> buildItems;

    public static UIManager uiManager;
    public static BuildManager buildManager;

    void Start()
    {
        LoadBuildManager();
        LoadUIManager();

        LoadBuildItems();
    }

    public static void LoadUIManager()
    {
        uiManager = GameObject.Find("_UIManager").GetComponent<UIManager>();
    }

    public static void LoadBuildManager()
    {
        buildManager = GameObject.Find("_BuildManager").GetComponent<BuildManager>();
    }

    public static void LoadBuildItems()
    {
        buildItems = ModController.LoadBuildItems();
    }

    void Update()
    {
        if (Input.GetKeyDown("n"))
            NextRound();
    }

    public void NextRound()
    {
        foreach (BuildItem item in buildItems)
            item.OnNextRound();

        if (buildItems.Count == 0)
            Debug.Log("THERE ARE NO BUILDITEMS");
    }
}
