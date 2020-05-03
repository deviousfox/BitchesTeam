using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutRope : MonoBehaviour
{
    [SerializeField] private GameObject _firstel;
    void FixedUpdate()
    {
        gameObject.transform.rotation = _firstel.transform.rotation;
    }
    void OnMouseDown()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
