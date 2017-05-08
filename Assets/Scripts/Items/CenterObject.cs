using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterObject : MonoBehaviour
{

    List<BuildItemMono> bim = new List<BuildItemMono>();

    void Update()
    {
        if (GameManager.hasChanged)
        {
            bim.Clear();

            GameObject[] go = GameObject.FindGameObjectsWithTag("BuildItem");

            for (int i = 0; i < go.Length; i++)
               bim.Add(  go[i].GetComponent<BuildItemMono>());

        }
    }

}
