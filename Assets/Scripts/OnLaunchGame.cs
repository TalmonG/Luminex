using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLaunchGame : MonoBehaviour
{
    public PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript.currentLevel = -6;
        PlayerPrefs.SetInt("currentLevel", playerScript.currentLevel);
    }

}
