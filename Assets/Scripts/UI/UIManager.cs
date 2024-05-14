using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    private GameObject[] keyBindButtons;

    private void Awake()
    {
        keyBindButtons = GameObject.FindGameObjectsWithTag("keybind");
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickStartButton()
    {
        SceneManager.LoadScene("Opening text");
    }

    public void onClickLoadButton()
    {
        SceneManager.LoadScene("Load");
    }

    public void onClickOptionsButton()
    {
        SceneManager.LoadScene("Options_Controls");
    }

    public void onClickAudioButton()
    {
        SceneManager.LoadScene("Options_Audio");
    }

    public void onClickGraphicsButton()
    {
        SceneManager.LoadScene("Options_Graphics");
    }

    public void onClickHomeButton()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void onClickQuitButton()
    {
        Application.Quit();
    }

    public void OnClikcCreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void updateKeyText(string key, KeyCode code)
    {
        GameObject keyBindButton = Array.Find(keyBindButtons, x => x.name == key);
        if (keyBindButton != null)
        {
            TextMeshProUGUI tmp = keyBindButton.GetComponentInChildren<TextMeshProUGUI>();
            if (tmp != null)
            {
                tmp.text = code.ToString();
            }
            else
            {
                Debug.LogError("TextMeshPro component not found on key bind button: " + key);
            }
        }
        else
        {
            Debug.LogError("Key bind button not found: " + key);
        }
    }

    private void OnRebindButtonClicked(string key)
    {
        KeyBindManager.MyInstance.RebindKey(key);
    }
}
