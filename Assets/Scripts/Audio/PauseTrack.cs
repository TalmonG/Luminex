using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTrack : MonoBehaviour
{
    private AudioSource AudioSource;
    public GameObject Music;

    void Start()
    {
        Music = GameObject.FindGameObjectWithTag("GameMusic");
        AudioSource = Music.GetComponent<AudioSource>();
        AudioSource.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
