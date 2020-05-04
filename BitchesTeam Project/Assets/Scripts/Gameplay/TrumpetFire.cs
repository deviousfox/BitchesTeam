using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpetFire : MonoBehaviour
{
    [SerializeField] private GameObject _fireelement;
   void OnTriggerEnter2D(Collider2D coll)
   {
        switch(coll.gameObject.tag)
        {
            case "Stone":
                _fireelement.SetActive(false);
                break;
            default:
                break;
        }

   }
}
