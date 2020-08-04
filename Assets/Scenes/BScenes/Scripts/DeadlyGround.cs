using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyGround : MonoBehaviour
{
    public DamageHandler damageHandler;

    private void OnTriggerEnter(Collider other)
    {
        damageHandler.DealDamage(DamageHandler.damageType.deadly_surface, 100f, other.gameObject);
    }
}