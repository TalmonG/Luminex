using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Referencing
    public PlayerScript playerScript;

    public GameObject Music;
    private AudioSource audioSource;

    private void Start()
    {
        Music = GameObject.FindGameObjectWithTag("GameMusic");
        audioSource = Music.GetComponent<AudioSource>(); 
    }
    public void loadNewScene()
    {
        playerScript.currentLevel = -6;
        Debug.Log(playerScript.currentLevel);
        SceneManager.LoadScene("StartMenu");
        audioSource.Play();
    }
}
