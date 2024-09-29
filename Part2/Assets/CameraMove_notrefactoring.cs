using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove_not : MonoBehaviour
{
    GameObject CameraParent;

    Vector3 defaultPosition;
    Quaternion defaultRotation;
    float defaultZoom;

    void Start()
    {
        CameraParent = GameObject.Find("CameraParent");

        defaultPosition = Camera.main.transform.position;
        defaultRotation = CameraParent.transform.rotation;
        defaultZoom = Camera.main.fieldOfView;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Camera.main.transform.Translate(Input.GetAxisRaw("Mouse X") / 10, Input.GetAxisRaw("Mouse Y") / 10, 0);
        }
        else if (Input.GetMouseButton(1))
        {
            CameraParent.transform.Rotate(Input.GetAxisRaw("Mouse Y") * 10, Input.GetAxisRaw("Mouse X") * 10, 0);
        }

        Camera.main.fieldOfView += 20 * Input.GetAxis("Mouse ScrollWheel");

        if (Camera.main.fieldOfView < 10) Camera.main.fieldOfView = 10;

        if (Input.GetMouseButton(2))
        {
            Camera.main.transform.position = defaultPosition;
            CameraParent.transform.rotation = defaultRotation;
            Camera.main.fieldOfView = defaultZoom;
        }
    }
}