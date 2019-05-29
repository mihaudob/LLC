using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;
    public Transform spawnPrefab;
    public Transform deathPrefab;
    public Transform coinPrefab;
    public Transform coinPoint;
    public Transform chestPrefab;
    public Transform chestPoint;
    public Transform bloodPrefab;

    private void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public IEnumerator RespawnPlayer (Player player)
    {
        yield return new WaitForSeconds(spawnDelay);
        player.gameObject.SetActive(true);
        player.gameObject.transform.position = spawnPoint.position;
        player.Respawn();
        Transform clone = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation) as Transform;
        Destroy(clone.gameObject, 3f);
    }

    public IEnumerator DeathAnimation(Player player)
    {
        Vector3 playerPosition = player.gameObject.transform.position;
        player.playerStats.health = 0;
        // player.gameObject.GetComponent<Animator>().Play("Walk");
        player.gameObject.SetActive(false);
        Transform death = Instantiate(deathPrefab, playerPosition, new Quaternion());
        yield return new WaitForSeconds(0.2f);  // hardcoded time of animation
        Destroy(death.gameObject);
    }

    public IEnumerator EnemyDeathAnim(Enemy enemy)
    {
        Vector3 enemyPosition = enemy.gameObject.transform.position;
        Transform death = Instantiate(deathPrefab, enemyPosition, new Quaternion());
        yield return new WaitForSeconds(0.2f);
        Destroy(death.gameObject);
    }

    public IEnumerator CoinCollectAnimation(Transform coinPoint)
    {
        Instantiate(coinPrefab, coinPoint.position, coinPoint.rotation);
        yield return false;
    }

    public IEnumerator ChestCollectAnimation(Transform chestPoint)
    {
        Instantiate(chestPrefab, chestPoint.position, chestPoint.rotation);
        yield return false;
    }

    public IEnumerator BloodAnimation(Player player)
    {
        Vector3 playerPosition = player.gameObject.transform.position;
        Transform blood = Instantiate(bloodPrefab, playerPosition, new Quaternion());
        yield return new WaitForSeconds(0.5f);
        Destroy(blood.gameObject);
    }

    public IEnumerator EnemyBloodAnimation(Enemy enemy)
    {
        Vector3 enemyPosition = enemy.gameObject.transform.position;
        Transform blood = Instantiate(bloodPrefab, enemyPosition, new Quaternion());
        yield return new WaitForSeconds(0.5f);
        Destroy(blood.gameObject);
    }

    public static void CollectCoin(Transform coinPoint)
    {
        gm.StartCoroutine(gm.CoinCollectAnimation(coinPoint));
    }

    public static void CollectChest(Transform chestPoint)
    {
        gm.StartCoroutine(gm.ChestCollectAnimation(chestPoint));
    }

    public static void ShowBlood(Player player)
    {
        gm.StartCoroutine(gm.BloodAnimation(player));
    }

    public static void EnemyShowBlood(Enemy enemy)
    {
        gm.StartCoroutine(gm.EnemyBloodAnimation(enemy));
    }

    public static void KillPlayer (Player player)
    {
        gm.StartCoroutine(gm.DeathAnimation(player));
        gm.StartCoroutine(gm.RespawnPlayer(player));
    }

    public static void KillEnemy (Enemy enemy)
    {
        gm.StartCoroutine(gm.EnemyDeathAnim(enemy));
        Destroy(enemy.gameObject);
    }
}
