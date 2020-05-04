using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeRotation : MonoBehaviour
{ 
    void OnMouseDown()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - 90);
    }
}
