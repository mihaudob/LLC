using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public KeyCode changePlayers;
    public StaticFromMenu staticVariables;
    public string thisCharacterName = "First";
    public int characterNumber = 3;
    public int mageGravity = 2;
    public int maceManGravity = 2;
    public int ghostGravity = 2;
    public float howHighPutCamera = 1;
    public float howHighPutRest = 1;
    public GameObject mage;
    public GameObject ghost;
    public GameObject maceMan;
    public GameObject playerPosition;

    int characterSelected = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(thisCharacterName == "First")
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
            mage.GetComponent<BoxCollider2D>().enabled = true;
            ghost.GetComponent<BoxCollider2D>().enabled = false;
            maceMan.GetComponent<BoxCollider2D>().enabled = false;

            mage.GetComponent<SpriteRenderer>().enabled = true;
            ghost.GetComponent<SpriteRenderer>().enabled = false;
            maceMan.GetComponent<SpriteRenderer>().enabled = false;

            mage.GetComponent<Player>().enabled = true;
            ghost.GetComponent<Player>().enabled = false;
            maceMan.GetComponent<Player>().enabled = false;

            playerPosition.GetComponent<Transform>().position = new Vector2(mage.GetComponent<Transform>().position.x, mage.GetComponent<Transform>().position.y + howHighPutCamera);
            maceMan.GetComponent<Transform>().position = new Vector2(mage.GetComponent<Transform>().position.x, mage.GetComponent<Transform>().position.y + howHighPutRest/2);
            ghost.GetComponent<Transform>().position = new Vector2(mage.GetComponent<Transform>().position.x, mage.GetComponent<Transform>().position.y + howHighPutRest/2);

            mage.GetComponent<Animator>().enabled = true;
            ghost.GetComponent<Animator>().enabled = false;
            maceMan.GetComponent<Animator>().enabled = false;

            maceMan.GetComponent<Rigidbody2D>().gravityScale = 0;
            ghost.GetComponent<Rigidbody2D>().gravityScale = 0;
            mage.GetComponent<Rigidbody2D>().gravityScale = mageGravity;

            mage.GetComponent<FireballCaster>().enabled = true;
        }
        if (characterSelected == 2)
        {

            mage.GetComponent<BoxCollider2D>().enabled = false;
            ghost.GetComponent<BoxCollider2D>().enabled = true;
            maceMan.GetComponent<BoxCollider2D>().enabled = false;

            mage.GetComponent<SpriteRenderer>().enabled = false;
            ghost.GetComponent<SpriteRenderer>().enabled = true;
            maceMan.GetComponent<SpriteRenderer>().enabled = false;

            mage.GetComponent<Player>().enabled = false;
            ghost.GetComponent<Player>().enabled = true;
            maceMan.GetComponent<Player>().enabled = false;

            playerPosition.GetComponent<Transform>().position = new Vector2(ghost.GetComponent<Transform>().position.x, ghost.GetComponent<Transform>().position.y + howHighPutCamera);
            mage.GetComponent<Transform>().position = new Vector2(ghost.GetComponent<Transform>().position.x, ghost.GetComponent<Transform>().position.y + howHighPutRest/2);
            maceMan.GetComponent<Transform>().position = new Vector2(ghost.GetComponent<Transform>().position.x, ghost.GetComponent<Transform>().position.y + howHighPutRest/2);

            mage.GetComponent<Animator>().enabled = false;
            ghost.GetComponent<Animator>().enabled = true;
            maceMan.GetComponent<Animator>().enabled = false;

            maceMan.GetComponent<Rigidbody2D>().gravityScale = 0;
            mage.GetComponent<Rigidbody2D>().gravityScale = 0;
            ghost.GetComponent<Rigidbody2D>().gravityScale = ghostGravity;

            mage.GetComponent<FireballCaster>().enabled = false;
        }
        if (characterSelected == 3)
        {


            mage.GetComponent<BoxCollider2D>().enabled = false;
            ghost.GetComponent<BoxCollider2D>().enabled = false;
            maceMan.GetComponent<BoxCollider2D>().enabled = true;

            mage.GetComponent<SpriteRenderer>().enabled = false;
            ghost.GetComponent<SpriteRenderer>().enabled = false;
            maceMan.GetComponent<SpriteRenderer>().enabled = true;

            mage.GetComponent<Player>().enabled = false;
            ghost.GetComponent<Player>().enabled = false;
            maceMan.GetComponent<Player>().enabled = true;

            playerPosition.GetComponent<Transform>().position = new Vector2(maceMan.GetComponent<Transform>().position.x, maceMan.GetComponent<Transform>().position.y + howHighPutCamera);
            ghost.GetComponent<Transform>().position = new Vector2(maceMan.GetComponent<Transform>().position.x, maceMan.GetComponent<Transform>().position.y + howHighPutRest/2);
            mage.GetComponent<Transform>().position = new Vector2(maceMan.GetComponent<Transform>().position.x, maceMan.GetComponent<Transform>().position.y + howHighPutRest/2);

            mage.GetComponent<Animator>().enabled = false;
            ghost.GetComponent<Animator>().enabled = false;
            maceMan.GetComponent<Animator>().enabled = true;
            
            mage.GetComponent<Rigidbody2D>().gravityScale = 0;
            ghost.GetComponent<Rigidbody2D>().gravityScale = 0;
            maceMan.GetComponent<Rigidbody2D>().gravityScale = maceManGravity;

            mage.GetComponent<FireballCaster>().enabled = false;
        }
    }
}
