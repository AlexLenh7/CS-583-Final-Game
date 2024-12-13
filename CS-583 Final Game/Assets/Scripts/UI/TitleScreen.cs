using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private AudioClip interactSound;

    public void Play()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
        SoundManager.instance.PlaySound(interactSound);
    }

    public void Quit()
    {
        SoundManager.instance.PlaySound(interactSound);
        Application.Quit();
    }
}