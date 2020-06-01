using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerBody body;
    private PlayerHead head;

    void Start()
    {
        body = body ?? GetComponentInChildren<PlayerBody>();
        head = head ?? GetComponentInChildren<PlayerHead>();
    }

    // TODO:
    // move from treasures,
    // or any level target
}
