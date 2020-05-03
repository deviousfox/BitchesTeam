//   !!!WARNING!!!
// This code writing
//   by deviousFox
//    END WARNING

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float YBorderAbs,XBorderAbs;

    private Camera cam;

    private Transform cameraTransform;
    private Vector3 cameraMovementDirection;
    private Vector3 touchPosition;

    private void Start()
    {
        cam = null ?? GetComponent<Camera>();
        cameraTransform = null ?? GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            cameraMovementDirection = touchPosition - cam.ScreenToWorldPoint(Input.mousePosition);
            cameraTransform.position += cameraMovementDirection + Vector3.back;
            cameraTransform.position = new Vector3(Mathf.Clamp(cameraTransform.position.x, -XBorderAbs, XBorderAbs), Mathf.Clamp(cameraTransform.position.y, -YBorderAbs, YBorderAbs),-10);
        }
    }
}
