using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFromMenu : MonoBehaviour
{
    static int playerAChoice = 1;
    static int playerBChoice = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPlayerAChoice(int playerButton)
    {
        playerAChoice = playerButton;
        Debug.Log(playerAChoice);
    }
    public void SetPlayerBChoice(int playerButton)
    {
        playerBChoice = playerButton;
        Debug.Log(playerAChoice);
    }

    public int GetPlayerAChoice()
    {
        return playerAChoice;
    }

    public int GetPlayerBChoice()
    {
        return playerBChoice;
    }
}
