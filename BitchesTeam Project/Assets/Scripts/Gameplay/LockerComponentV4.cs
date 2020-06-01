//   !!!WARNING!!!
// This code writing
//   by deviousFox
//    END WARNING

using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

class LockerComponentV4 : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public SpriteRenderer LockerEar;
    public Transform StartTransform;
    public Transform EndTransform;
    public Transform LockerTransform;
    public LayerMask ObstacleMask;

    private void Start()
    {
        LockerTransform.position = StartTransform.position;
    }
    public void LockerInteract()
    {
        Vector2 direction = EndTransform.position - StartTransform.position;
        RaycastHit2D[] raycastHits = Physics2D.RaycastAll(StartTransform.position, direction, ObstacleMask);
        if (raycastHits.Length >= 1)
        {
            print(raycastHits.Length);
            print("raycastHits[0]" + raycastHits[0].transform.name);
            for (int i = 0; i <raycastHits.Length; i++)
            {
              print(  raycastHits[i].transform.name);
            }
            if (raycastHits[0].transform.parent == LockerTransform)
            {
                print("J is"+LockersCounting(raycastHits));
                if (LockersCounting(raycastHits)<=1)
                {
                    StartCoroutine(MoveLocker());
                }
                else
                {
                    StartCoroutine(LockIndication());
                }
            }
            else { StartCoroutine(LockIndication()); }

        }
        else if (raycastHits.Length == 0)
        {
            StartCoroutine(MoveLocker());
        }
        else
        {
            StartCoroutine(LockIndication());
        }

    }

    IEnumerator MoveLocker()
    {
        print("Coroutine is START");
        while (LockerTransform.position != EndTransform.position) // Возможно придется поиграться с условием
        {
            LockerTransform.position = Vector3.Lerp(LockerTransform.position, EndTransform.position, MoveSpeed * Time.deltaTime);
            yield return null;
        }
        yield break;
    }
    IEnumerator LockIndication()
    {
        float indicationTime = 5f;
        Color tempColor = LockerEar.color;

        while (indicationTime >0)
        {
            
            indicationTime -= Time.deltaTime;
            Color indicationColor = Color.Lerp(tempColor, Color.red, Mathf.PingPong(Time.time, 1));
            LockerEar.color = indicationColor;
            
            yield return null;
        }
        LockerEar.color = tempColor;
        yield break;
    }

    private int LockersCounting(RaycastHit2D[] arr)
    {
        int j = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].collider.CompareTag("Stick"))
            {
                j++;
            }
        }
        return j;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(StartTransform.position, EndTransform.position - StartTransform.position);
    }


}


