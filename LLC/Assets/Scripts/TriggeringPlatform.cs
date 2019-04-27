using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeringPlatform : MonoBehaviour
{
    public GameObject Manager;
    MovingPlatform movingPlatform;
    int iteration = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            movingPlatform = Manager.gameObject.GetComponent<MovingPlatform>();
            if (iteration % 2 == 0)
            {
                movingPlatform.enabled = true;
            }
            else
            {
                movingPlatform.enabled = false;
            }
            iteration++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    }
}