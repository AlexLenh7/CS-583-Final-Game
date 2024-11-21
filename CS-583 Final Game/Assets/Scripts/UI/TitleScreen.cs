using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}