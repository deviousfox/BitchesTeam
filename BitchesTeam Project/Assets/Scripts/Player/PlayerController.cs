using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public LayerMask TargetsMask;

    [SerializeField] private float _speed;

    [SerializeField] private bool _canMove;

    private PlayerBody _body;
    private PlayerHead _head;


    private List<TargetObject> _targets;
    private TargetObject _currentTarget;

    private void OnMouseDown()
    {
        _canMove = !_canMove;
    }

    void Start()
    {
        _body = _body ?? GetComponentInChildren<PlayerBody>();
        _head = _head ?? GetComponentInChildren<PlayerHead>();
        _targets = FindObjectsOfType<TargetObject>().ToList();

        GetCurrentTarget(_targets);
    }

    private void Update()
    {
        if (_canMove)
        {
            if (CanTouchTarget())
            {
                MoveToTarget();
            }
            else
            {
                _canMove = !_canMove; 
            }
        }
    }

    public TargetObject GetCurrentTarget(List<TargetObject> targetObjects)
    {
        var obj = from t in targetObjects
                  orderby t.PriorityWeigth
                  select t;
        _currentTarget = obj.ToList()[0];
        return _currentTarget;
    }

    public bool CanTouchTarget()
    {
        Transform targetTransform = _currentTarget.transform;
        Vector2 direction = targetTransform.position - transform.position;
        RaycastHit2D targetHit = Physics2D.Raycast(transform.position, direction,100f, TargetsMask);
        if (targetHit.transform == targetTransform)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MoveToTarget()
    {
        Vector3 direction = _currentTarget.transform.position - transform.position;
        direction.Normalize();
        direction = new Vector3(direction.x, 0, 0);
        transform.position += direction * Time.deltaTime * _speed;
    }
    // TODO:
    // smooth move and target serch
}
