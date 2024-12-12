using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    private GameObject playableChar;

    [SerializeField] GameObject playerSpawner;
    private bool gameStarted = false;

    public GameObject gameOverUI;


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
                gameOver();
                //Change scene if needed
            }

            //More checks for whatever circumstances here
        }

    }

    void gameOver()
    {
        // Display game over screen
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart successful");
    }

    public void Menu()
    {
        SceneManager.LoadScene("TitleScreen");
        Debug.Log("Back to Title screen");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit successful");
    }

}
