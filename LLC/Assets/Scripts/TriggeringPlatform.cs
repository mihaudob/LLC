using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeringPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Weszedł");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Wyszed");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Siedzi");

    }
}
