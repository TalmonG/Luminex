using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene(2);
    }


}
