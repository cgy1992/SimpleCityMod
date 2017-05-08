using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildManager : MonoBehaviour {

    List<BuildItem> buildItems = new List<BuildItem>();
    public BuildItem selectedItem = new BuildItem();

    void Start()
    {
        GameManager.LoadUIManager();
        GameManager.LoadBuildItems();

        buildItems = GameManager.buildItems;

        foreach (BuildItem item in buildItems)
        {
            try
            {
                GameManager.uiManager.SetupBuildItem(item);
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
                throw;
            }

        }
    }

    public void SelectItem(BuildItem bi)
    {
        Debug.Log("Selecting item " + bi.DisplayName);
        selectedItem = bi;
    }

}
