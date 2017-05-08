using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public int speed;

    Camera cam;

	void Start ()
    {
        cam = GetComponent<Camera>();
	}
	
	void Update ()
    {
        if (Input.GetKey("d"))
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey("a"))
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (Input.GetKey("w"))
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKey("s"))
            transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
