using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Andras.ModTools;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject buildItemObject;
    public Transform parentPanel;

    public void SetupBuildItem(BuildItem bi)
    {
        GameObject go = Instantiate(buildItemObject, parentPanel) as GameObject;

        go.GetComponentInChildren<Text>().text = bi.DisplayName + " costs $" + bi.BuildCost;
        go.GetComponentInChildren<Image>().sprite = bi.DisplayImage;

        go.GetComponentInChildren<Button>().onClick.AddListener(() => GameManager.buildManager.SelectItem(bi));
    }
}
