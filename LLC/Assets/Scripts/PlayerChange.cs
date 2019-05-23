using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public KeyCode changePlayers;
    int characterSelect = 1;
    GameObject mage, ghost, maceMan;
    // Start is called before the first frame update
    void Start()
    {
        mage = GameObject.Find("Mage");
        ghost = GameObject.Find("Ghost");
        maceMan = GameObject.Find("MaceMan");
    }

    void Update()
    {
        if (Input.GetKeyDown(changePlayers))
        {
            characterSelect++;
            if(characterSelect == 4)
            {
                characterSelect = 1;
            }
        }
        if(characterSelect == 1)
        {
            mage.SetActive(true);
            ghost.SetActive(false);
            maceMan.SetActive(false);
        }
        if (characterSelect == 2)
        {
            mage.SetActive(false);
            ghost.SetActive(true);
            maceMan.SetActive(false);
        }
        if (characterSelect == 3)
        {
            mage.SetActive(false);
            ghost.SetActive(false);
            maceMan.SetActive(true);
        }
    }
}
