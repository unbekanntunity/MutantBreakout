using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageHandler : MonoBehaviour
{
    public int GameOverScene;
    public enum damageType
    {
        deadly_surface
    }

    public void DealDamage(damageType damageType, float damageAmount, GameObject damageReceiver)
    {
        Health Target = damageReceiver.GetComponent<Health>();

        float health_Target = Target.health;

        health_Target -= damageAmount;

        Target.health = health_Target;

        if (health_Target <= 0)
        {
            Die(damageReceiver);
        }


    }

    public void Die(GameObject deadlydamageReceiver)
    {
        if (deadlydamageReceiver.tag == "Player")
        {
            SceneManager.LoadScene(GameOverScene);
        }
        else
        {
            Destroy(this);
        }
    }
}