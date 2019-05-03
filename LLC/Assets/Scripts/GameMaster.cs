using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    private void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;
    public Transform spawnPrefab;
    public Transform deathPrefab;

    public IEnumerator RespawnPlayer (Player player)
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Transform clone = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation) as Transform;
        Destroy(clone.gameObject, 3f);
    }

    public IEnumerator DeathAnimation(Player player)
    {
        Vector3 playerPosition = player.gameObject.transform.position;
        Destroy(player.gameObject);
        Transform death = Instantiate(deathPrefab, playerPosition, new Quaternion());
        yield return new WaitForSeconds(0.2f);  // hardcoded time of animation
        Destroy(death.gameObject);
    }

    public static void KillPlayer (Player player)
    {
        gm.StartCoroutine(gm.DeathAnimation(player));
        gm.StartCoroutine(gm.RespawnPlayer(player));
    }
}
