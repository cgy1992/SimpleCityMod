using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterObject : MonoBehaviour
{

    List<BuildItemMono> bims = new List<BuildItemMono>();

    Vector3 location;

    void Update()
    {
        if (GameManager.hasChanged)
        {
            bims.Clear();

            GameObject[] go = GameObject.FindGameObjectsWithTag("BuildItem");

            for (int i = 0; i < go.Length; i++)
            {
                bims.Add(go[i].GetComponent<BuildItemMono>());
                location += go[i].transform.position;
            }

            location /= go.Length;
        }


        transform.position = Vector3.Slerp(transform.position, location, 0.2f);
    }

}
