using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject Music;
    private AudioSource audioSource;

    private void Start()
    {
        Music = GameObject.FindGameObjectWithTag("GameMusic");
        audioSource = Music.GetComponent<AudioSource>(); 
    }
    public void loadNewScene()
    {
        SceneManager.LoadScene("StartMenu");
        audioSource.Play();
    }
}
