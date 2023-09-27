using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledgeHammer : MonoBehaviour
{
    public float damageDealt = 20f;
    public float attackSpeed = 1f;
    [SerializeField] TwoDPlayerAnimation twoDPlayer;

    public void Attack(GameObject enemy)
    {
        EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
        enemyBehaviour.health -= Mathf.RoundToInt(damageDealt / enemyBehaviour.damageCushioning);
        if (enemyBehaviour.health <= 0f)
        {
            enemyBehaviour.Death();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Enemy") == true && twoDPlayer.slashing)
        {
            Debug.Log("Hit");
            Attack(collision.gameObject);
        }
    }
}
