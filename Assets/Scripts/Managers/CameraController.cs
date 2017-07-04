using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public int speed;
    public float scrollSpeed;
    public float lerpSpeed;
    Camera cam;

    public Transform moveToPos;

    float camFOV;

	void Start ()
    {
        cam = GetComponent<Camera>();
        camFOV = cam.fieldOfView;

        moveToPos.position = transform.position;
    }
	
	void Update ()
    {
        if (Input.GetKey("d"))
            moveToPos.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey("a"))
            moveToPos.Translate(Vector3.left * speed * Time.deltaTime);

        if (Input.GetKey("w"))
            moveToPos.Translate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKey("s"))
            moveToPos.Translate(Vector3.down * speed * Time.deltaTime);

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            camFOV += scrollSpeed;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            camFOV -= scrollSpeed;

        Debug.Log(moveToPos);

        camFOV = Mathf.Clamp(camFOV, 3, 120);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, camFOV, 0.2f);

        transform.position = Vector3.Lerp(transform.position, moveToPos.position, lerpSpeed);

        transform.LookAt(GameManager.centerObject.gameObject.transform);
        moveToPos.LookAt(GameManager.centerObject.gameObject.transform);
    }
}
