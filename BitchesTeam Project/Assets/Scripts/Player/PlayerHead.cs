using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    private float health;
    public float Health { get => health; set => health = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LiquidComponent _otherLiquid = collision.GetComponent<LiquidComponent>();
        if (_otherLiquid != null)
        {
            if (_otherLiquid?.GetLiquidType() != LiquidType.Water)
            {
                Health -= _otherLiquid.GetDamage();
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        LiquidComponent _otherLiquid = collision.GetComponent<LiquidComponent>();
        if (_otherLiquid?.GetLiquidType() == LiquidType.Water)
        {
            //TODO: water damage
        }
    }
    // TODO: water 'n' lava 'n' acid DAMAGE MYAHAHAHAHAHAHA!
}
