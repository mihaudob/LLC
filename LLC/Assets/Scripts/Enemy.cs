using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [System.Serializable]
    public class EnemyStats
    {
        public int Health = 100;
    }

    public EnemyStats stats = new EnemyStats();

    public int fallBoundary = -5;

    private void Update()
    {
        if (transform.position.y <= fallBoundary)
        {
            DamageEnemy(9999999);
        }
    }

    public void DamageEnemy(int damage)
    {
        stats.Health -= damage;
        if (stats.Health <= 0)
        {
            GameMaster.KillEnemy(this);
        }
    }
}
