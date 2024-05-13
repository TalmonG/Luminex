using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{

    public GameObject pauseMenu , optionsControls , optionsAudio , optionsGraphics , options;

    // Start is called before the first frame update
    void Start()
    {
        
        pauseMenu.SetActive(false);
        optionsControls.SetActive(false);
        optionsAudio.SetActive(false);
        optionsGraphics.SetActive(false);
        options.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void onClickResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void onClickOptions()
    {
        pauseMenu.SetActive(false);
        optionsControls.SetActive(true);
        optionsAudio.SetActive(false);
        optionsGraphics.SetActive(false);
        options.SetActive(true);
    }


    public void onClickControls()
    {
        optionsControls.SetActive(true);
        optionsAudio.SetActive(false);
        optionsGraphics.SetActive(false);
    }
    public void onClickAudio()
    {
        optionsControls.SetActive(false);
        optionsAudio.SetActive(true);
        optionsGraphics.SetActive(false);
    }

    public void onClickGraphics()
    {
        optionsControls.SetActive(false);
        optionsAudio.SetActive(false);
        optionsGraphics.SetActive(true);
    }

    public void onClickHome()
    {
        pauseMenu.SetActive(true);
        optionsControls.SetActive(false);
        optionsAudio.SetActive(false);
        optionsGraphics.SetActive(false);
        options.SetActive(false);
    }

    public void onClickQuit()
    {
        Application.Quit();
    }
}
