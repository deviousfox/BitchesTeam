using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    [Tooltip("Скорость")]
    [SerializeField] private float _speed;
    [Tooltip("Активирование стрелы")]
    [SerializeField] private bool _isShot;


    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_isShot)
        {
            Vector2 scalex = new Vector2(gameObject.transform.localScale.x, 0);
            transform.Translate(scalex * _speed * Time.deltaTime);
        }
      
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Player":
                _isShot = false;
                print("<color=red><b>Стрела попала в игрока. Опишите действия</b></color>");
                break;
            case "Button":
                _isShot = false;
                print("<color=red><b>Стрела попала в кнопку. Опишите действия</b></color>");
                break;
            default:
                break;

        }

    }
}
