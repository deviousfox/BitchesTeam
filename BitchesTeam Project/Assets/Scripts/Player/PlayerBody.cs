using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private float health;
    public float Health { get => health; set => health = value; }
    // TODO: lava damage 'n' acid damage 'n' ???
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LiquidComponent _otherLiquid = collision.GetComponent<LiquidComponent>();
        if (_otherLiquid !=null)
        {
            if (_otherLiquid?.GetLiquidType() != LiquidType.Water)
            {
                Health -= _otherLiquid.GetDamage();
                Destroy(collision.gameObject);
            }
        }
       
    }
}
