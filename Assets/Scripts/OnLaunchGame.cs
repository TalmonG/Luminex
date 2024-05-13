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
            Debug.Log("FFFFFFFFFFF");
            Debug.Log("FFFFFFFFFFF" + PlayerPrefs.GetInt("currentLevel"));
        }
        else if (scene.name.Equals("Tutorial"))
        {

            //GameObject.FindWithTag("NormalDimensionTutorial").SetActive(true);
            //GameObject.FindWithTag("InvertedDimensionTutorial").SetActive(false);
            playerScript.isNormalDimension = true;
            playerScript.canSwitchDimensions = true;
            playerScript.currentLevel = 0;
            PlayerPrefs.SetInt("currentLevel", 0);
            Debug.Log("POOP" + playerScript.currentLevel);
            Debug.Log("Current Level Now Set To " + playerScript.currentLevel);
            Debug.Log("isNormalDimension set to: " + PlayerPrefs.GetInt("isNormalDimension"));
            Debug.Log("canSwitchDimensions set to: " + PlayerPrefs.GetInt("canSwitchDimensions"));
            Debug.Log("ARFFFFF" + PlayerPrefs.GetInt("currentLevel"));
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
    }
}
