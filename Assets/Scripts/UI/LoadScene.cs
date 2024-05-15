using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject Music;
    //public GameObject voice;
    private AudioSource audioSource;
    //public AudioSource speech;

    private void Start()
    {
        //Music = GameObject.FindGameObjectWithTag("GameMusic");
        //audioSource = Music.GetComponent<AudioSource>();
        //voice = GameObject.FindGameObjectWithTag("voiceover");
        //speech = audioSource.GetComponent<AudioSource>();
    }
    public void loadNewScene()
    {
       // audioSource.Play();
        SceneManager.LoadScene("StartMenu");
    }

    public void startaudio()
    {
        //  speech.Play();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
