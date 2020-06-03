using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private bool _canMove;

    private PlayerBody _body;
    private PlayerHead _head;


    private List<TargetObject> _targets;

    private void OnMouseDown()
    {
        _canMove = !_canMove;
    }

    void Start()
    {
        _body = _body ?? GetComponentInChildren<PlayerBody>();
        _head = _head ?? GetComponentInChildren<PlayerHead>();
        _targets = FindObjectsOfType<TargetObject>().ToList();
    }

    private void Update()
    {
        if (Time.renderedFrameCount%5 ==0 && _canMove)
        {
            MoveToTarget();
        }
    }

    public TargetObject GetCurrentTarget(List<TargetObject> targetObjects)
    {
        var obj = from t in targetObjects
                  orderby t.PriorityWeigth
                  select t;
        return obj.ToList()[0];
    }

    public void MoveToTarget()
    {
        Vector3 direction = GetCurrentTarget(_targets).transform.position - transform.position;
        direction.Normalize();
        direction = new Vector3(direction.x, 0, 0);
        transform.position += direction * Time.deltaTime * _speed;
    }
    // TODO:
    // smooth move and target serch
}
