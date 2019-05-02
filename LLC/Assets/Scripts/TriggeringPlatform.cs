using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeringPlatform : MonoBehaviour
{
    public GameObject Manager;
    MovingPlatform movingPlatform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            movingPlatform = Manager.gameObject.GetComponent<MovingPlatform>();
            movingPlatform.enabled = !movingPlatform.enabled;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    }
}