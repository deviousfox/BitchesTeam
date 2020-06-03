using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidComponent : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private LiquidType _liquidType;

    public LiquidType GetLiquidType()
    {
        return _liquidType;
    }
    public float GetDamage()
    {
        return _damage;
    }
}
