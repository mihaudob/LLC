using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public KeyCode changePlayers;
    public StaticFromMenu staticVariables;
    public string thiCharacterName = "First";
    public int characterNumber = 3;
    public GameObject mage;
    public GameObject ghost;
    public GameObject maceMan;

    int characterSelected = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(thiCharacterName == "First")
        {
            characterSelected = staticVariables.GetPlayerAChoice();

        }
        else
        {
            characterSelected = staticVariables.GetPlayerBChoice();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(changePlayers))
        {
            characterSelected++;
            if(characterSelected == characterNumber + 1)
            {
                characterSelected = 1;
            }
        }
        if(characterSelected == 1)
        {
            mage.GetComponent<SpriteRenderer>().enabled = true;
            ghost.GetComponent<SpriteRenderer>().enabled = false;
            maceMan.GetComponent<SpriteRenderer>().enabled = false;

            mage.GetComponent<Player>().enabled = true;
            ghost.GetComponent<Player>().enabled = false;
            maceMan.GetComponent<Player>().enabled = false;

            mage.GetComponent<Animator>().enabled = true;
            ghost.GetComponent<Animator>().enabled = false;
            maceMan.GetComponent<Animator>().enabled = false;
        }
        if (characterSelected == 2)
        {
            mage.GetComponent<SpriteRenderer>().enabled = false;
            ghost.GetComponent<SpriteRenderer>().enabled = true;
            maceMan.GetComponent<SpriteRenderer>().enabled = false;

            mage.GetComponent<Player>().enabled = false;
            ghost.GetComponent<Player>().enabled = true;
            maceMan.GetComponent<Player>().enabled = false;

            mage.GetComponent<Animator>().enabled = false;
            ghost.GetComponent<Animator>().enabled = true;
            maceMan.GetComponent<Animator>().enabled = false;
        }
        if (characterSelected == 3)
        {
            mage.GetComponent<SpriteRenderer>().enabled = false;
            ghost.GetComponent<SpriteRenderer>().enabled = false;
            maceMan.GetComponent<SpriteRenderer>().enabled = true;

            mage.GetComponent<Player>().enabled = false;
            ghost.GetComponent<Player>().enabled = false;
            maceMan.GetComponent<Player>().enabled = true;

            mage.GetComponent<Animator>().enabled = false;
            ghost.GetComponent<Animator>().enabled = false;
            maceMan.GetComponent<Animator>().enabled = true;

        }
    }
}
