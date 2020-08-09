using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//author: B_Live

public class DeadlyGround : MonoBehaviour
{
    public DamageHandler damageHandler;

    private void OnTriggerEnter(Collider other)
    {
        damageHandler.DealDamage(DamageHandler.DamageType.deadly_surface, 100f, other.gameObject);
    }
}