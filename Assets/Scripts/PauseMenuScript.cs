using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                Pause();
                isPaused = true;
                Debug.Log("You paused the game");
            }
            else
            {
                Resume();
                isPaused = false;
                Debug.Log("You resumed the game");
            }
        }
    }

    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("StartMenu");
    }

    public void SecretMainMenu()
    {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("SecretMainMenu");
    }

}