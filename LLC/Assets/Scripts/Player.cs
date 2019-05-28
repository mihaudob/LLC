using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerStats
{
    public int startHealth = 100;
    public int startLives = 3;
    public int startCoins = 0;

    [System.NonSerialized]
    public int health;
    [System.NonSerialized]
    public int lives;
    [System.NonSerialized]
    public int coins;

    public PlayerStats()
    {
        health = startHealth;
        lives = startLives;
        coins = startCoins;
    }
}

public class Player : MonoBehaviour
{
    public PlayerStats playerStats = new PlayerStats();
    public int fallBoundary = -5;

    private Text health;
    private Text lives;
    private Text coins;
    private Transform bloodPoint;

    private void Start()
    {
        health = GameObject.Find("Health").GetComponent<Text>();
        lives = GameObject.Find("Lives").GetComponent<Text>();
        coins = GameObject.Find("Coins").GetComponent<Text>();
    }

    private void Update()
    {
        bloodPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (transform.position.y <= fallBoundary)
        {
            DamagePlayer(99999);
        }
        UpdateUI();
    }

    private void OnDisable()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        health.text = playerStats.health.ToString();
        lives.text = playerStats.lives.ToString();
        coins.text = playerStats.coins.ToString();
    }

    public PlayerStats GetPlayerStats()
    {
        return playerStats;
    }

    public void DamagePlayer (int damage)
    {
        playerStats.health -= damage;
        if (playerStats.health <= 0)
        {
            playerStats.lives -= 1;
            GameMaster.KillPlayer(this);
        }
    }

    public void Respawn()
    {
        playerStats.health = new PlayerStats().health;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject coin;
        Transform coinPoint;
        switch (col.gameObject.tag)
        {
            case "Deadly":
                DamagePlayer(1000);
                break;
            case "Coin":
                coin = col.gameObject;
                coinPoint = coin.GetComponentInChildren<Transform>();
                playerStats.coins += 1;
                GameMaster.CollectCoin(coinPoint);
                // GameMaster.Destroy(GameObject.FindGameObjectWithTag("Coin"));
                GameMaster.Destroy(coin);
                break;
            case "Enemy":
                DamagePlayer(25);
                GameMaster.ShowBlood(this);
                break;
        }
    }
}
