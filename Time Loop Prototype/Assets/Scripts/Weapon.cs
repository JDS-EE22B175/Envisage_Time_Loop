using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon 
{
    public float damageDealt;
    public float attackSpeed;
    public GameObject weapon;

    public void Attack(GameObject enemy)
    {
        EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
        enemyBehaviour.health -= Mathf.RoundToInt(damageDealt / enemyBehaviour.damageCushioning);
        if(enemyBehaviour.health <= 0f)
        {
            enemyBehaviour.Death();
        }
    }
}
