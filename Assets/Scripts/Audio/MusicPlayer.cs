using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public Slider VolumeSlider;
    public GameObject objectMusic;

    //value from slide, and converts to volume
    private AudioSource AudioSource;
    private float musicVolume = 1f;

    void Start()
    {
        objectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = objectMusic.GetComponent<AudioSource>();

        //set volume
        musicVolume = PlayerPrefs.GetFloat("Volume");
        AudioSource.volume = musicVolume;
        if (VolumeSlider != null)
        {
            VolumeSlider.value = musicVolume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("Volume", musicVolume);
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }
}
