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

    [SerializeField] GameObject Boss;
    private GameObject Bosschar;

    public GameObject gameOverUI;
    public GameObject pauseMenu;
    public GameObject VictoryScreen;

    private bool gameWon = false;


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
        if (gameWon)
        return;

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (Bosschar == null)
        {
            Bosschar = GameObject.Find("BOSS");
        }
    }

    public void Victory()
    {
        gameWon = true;
        VictoryScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void gameOver()
    {
        // Display game over screen
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
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
