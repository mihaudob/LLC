﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public KeyCode specialMove;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public Transform attackPos;

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            //then you can attack
            if (Input.GetKey(specialMove))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().DamageEnemy(damage);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
