using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidSpawner : MonoBehaviour
{
    [Tooltip("Префаб жидкости")]
    [SerializeField] private GameObject _goPref;
    [Tooltip("Количество частиц жидкости")]
    [SerializeField] private int _liquidQuantity;
    void Start()
    {
        Spawner();
    }

    private void Spawner()
    {
        int quantity = 0;
        while (quantity <= _liquidQuantity)
        {
            Vector3 spawnpoint = new Vector3(Random.Range(0.3f,0.7f), Random.Range(0.3f, 0.7f),0f);
            Instantiate(_goPref,transform.position + spawnpoint, Quaternion.identity,transform);
            quantity++;
        }
    }
}
