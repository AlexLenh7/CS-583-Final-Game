using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    private GameObject playableChar;

    [SerializeField] GameObject playerSpawner;
    private bool gameStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        //Old Feature
        //playerSpawner = GameObject.Find("Player Spawn");
        //Instantiate(playerPrefab, playerSpawner.transform.position + new Vector3(0, 5, 0), Quaternion.Euler(0, 0, 0));

        playableChar = GameObject.Find("Player");

        gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarted)
        {
            if (playableChar.GetComponent<PlayerStats>().isDead == true)
            {
                Destroy(playableChar);
                gameStarted = false;
                //Invoke game over screen

                //Change scene if needed
            }

            //More checks for whatever circumstances here
        }


    }

    void gameOver()
    {
        // Display game over screen
    }
}
