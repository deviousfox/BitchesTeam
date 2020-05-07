//   !!!WARNING!!!
// This code writing
//   by deviousFox
//    END WARNING

using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

class LockerComponentV4 : MonoBehaviour, IPointerClickHandler
{
    public Transform StartTransform;
    public Transform EndTransform;
    public Transform LockerTransform;
    public LayerMask ObstacleMask;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (MoveLocker() == null)
        {
            Vector2 direction = EndTransform.position - StartTransform.position;
            RaycastHit2D[] raycastHits = Physics2D.RaycastAll(StartTransform.position, direction, ObstacleMask);
            if (raycastHits.Length == 1)
            {
               if( raycastHits[0].transform == LockerTransform)
               {
                   StartCoroutine(MoveLocker());
               }

            }
            else
            {
                //TODO Визуализация невозможности открытия.
            }
        }
    }
    
    IEnumerator MoveLocker()
    {
        while (LockerTransform.position != EndTransform.position) // Возможно придется поиграться с условием
        {

            yield return null;
        }
    }
}

