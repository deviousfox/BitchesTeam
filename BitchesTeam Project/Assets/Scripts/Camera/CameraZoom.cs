//   !!!WARNING!!!
// This code writing
//   by deviousFox
//    END WARNING

using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float ZoomMin, ZoomMax, ZoomSpeed;
    private Camera cam;
    private void Start()
    {
        cam = null ?? GetComponent<Camera>();
    }
    void Update()
    {
#if UNITY_EDITOR

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize+ Input.GetAxis("Mouse ScrollWheel"), ZoomMin, ZoomMax);

#else

        if (Input.touchCount == 2)
        {
            Zoom();
        }

#endif
    }

    public void Zoom()
    {
        Touch touchFirst = Input.GetTouch(0);
        Touch touchSecond = Input.GetTouch(1);

        Vector2 firstTouchLastPos = touchFirst.position - touchFirst.deltaPosition;
        Vector2 secondTouchLastPos = touchSecond.position - touchSecond.deltaPosition;

        float touchDistance = (firstTouchLastPos - secondTouchLastPos).magnitude;
        float currentTouchDistance = (touchFirst.position - touchSecond.position).magnitude;

        float distanceDifference = currentTouchDistance - touchDistance;

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - touchDistance * ZoomSpeed, ZoomMin, ZoomMax);
    }
}
