using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private PlayerBody body;
    private PlayerHead head;


    public List<TargetObject> Targets;

    void Start()
    {
        body = body ?? GetComponentInChildren<PlayerBody>();
        head = head ?? GetComponentInChildren<PlayerHead>();
        Targets = FindObjectsOfType<TargetObject>().ToList();
    }

    private void Update()
    {
        if (Time.renderedFrameCount%5 ==0)
        {
            Vector3 direction = GetCurrentTarget(Targets).transform.position - transform.position;
            direction.Normalize();
            direction = new Vector3(direction.x, 0, 0);
            transform.position += direction * Time.deltaTime*speed;
        }
    }
    public TargetObject GetCurrentTarget(List<TargetObject> targetObjects)
    {
        var obj = from t in targetObjects
                  orderby t.PriorityWeigth
                  select t;
        return obj.ToList()[0];
    }
    // TODO:
    // move from treasures,
    // or any level target
}
