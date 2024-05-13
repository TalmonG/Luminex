using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OnLaunchGame : MonoBehaviour
{
    public PlayerScript playerScript;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoadedTwo;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoadedTwo;
    }


    public void OnSceneLoadedTwo(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals("StartMenu"))
        {
            // playerScript.currentLevel = -15;
            PlayerPrefs.SetInt("currentLevel", -25);
        }
        else if (scene.name.Equals("Tutorial"))
        {
            playerScript.isNormalDimension = true;
            playerScript.canSwitchDimensions = true;
            playerScript.currentLevel = 0;
            PlayerPrefs.SetInt("currentLevel", 0);
            PlayerPrefs.SetInt("currentLevel", 0);

            // Check if playerScript is assigned
            if (playerScript != null)
            {
                // Set currentLevel
                playerScript.currentLevel = 0;
                PlayerPrefs.SetInt("currentLevel", playerScript.currentLevel);

                // Verify the value has been set
                Debug.Log("Current Level Now Set To " + PlayerPrefs.GetInt("currentLevel"));
            }
            else
            {
                Debug.LogError("PlayerScript not assigned to OnLaunchGame!");
            }

        }
        else if (scene.name.Equals("Zone1_Level1"))
        {
            playerScript.isNormalDimension = true;
            playerScript.canSwitchDimensions = true;
            playerScript.currentLevel = 1;
            PlayerPrefs.SetInt("currentLevel", 1);
            PlayerPrefs.SetInt("currentLevel", 1);

            // Check if playerScript is assigned
            if (playerScript != null)
            {
                // Set currentLevel
                playerScript.currentLevel = 1;
                PlayerPrefs.SetInt("currentLevel", playerScript.currentLevel);

                // Verify the value has been set
                Debug.Log("Current Level Now Set To " + PlayerPrefs.GetInt("currentLevel"));
            }
            else
            {
                Debug.LogError("PlayerScript not assigned to OnLaunchGame!");
            }
        }

    }
}
