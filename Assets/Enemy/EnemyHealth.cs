using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void DamageEnemy(float damageValue)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damageValue;
        if(hitPoints < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
