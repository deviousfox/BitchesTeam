using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSayObject : MonoBehaviour
{
    public UnityEvent SayingMethod;

    private void OnMouseDown()
    {
        SayingMethod?.Invoke();
    }
}
