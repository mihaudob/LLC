using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public int Health = 100;
    }

    public PlayerStats playerStats = new PlayerStats();

    public int fallBoundary = -10;

    private void Update()
    {
        if (transform.position.y <= fallBoundary)
        {
            DamagePlayer (9999999);
        }
    }

    public void DamagePlayer (int damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }

    public void Respawn()
    {
        // TODO reset health and other stuff + handle players death (maybe reset points?)
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Deadly")
        {
            GameMaster.KillPlayer(this);
        }
    }
}
