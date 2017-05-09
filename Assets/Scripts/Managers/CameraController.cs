using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public int speed;
    public float scrollSpeed;
    Camera cam;

    float camFOV;

	void Start ()
    {
        cam = GetComponent<Camera>();
        camFOV = cam.fieldOfView;
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

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            camFOV += scrollSpeed;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            camFOV -= scrollSpeed;


        camFOV = Mathf.Clamp(camFOV, 3, 120);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, camFOV, 0.2f);

        transform.LookAt(GameManager.centerObject.gameObject.transform);
    }
}
