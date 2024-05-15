using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OnLaunchGame : MonoBehaviour
{
    public PlayerScript playerScript;
    public PauseMenu pauseMenuScript;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoadedTwo;
    }

    void Start()
    {

        playerScript.SetPlayerPrefs();
        pauseMenuScript.isPaused = false;
        pauseMenuScript.pauseMenu.SetActive(false);
        playerScript.SetPlayerPrefs();
        Debug.Log("BOBMARKLEY");
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
        if (scene.name.Equals("Credits"))
        {
            // playerScript.currentLevel = -15;
            PlayerPrefs.SetInt("currentLevel", -2);
        }
        else if (scene.name.Equals("HUB Level"))
        {
            playerScript.isNormalDimension = true;
            playerScript.canSwitchDimensions = false;
            playerScript.currentLevel = -1;
            PlayerPrefs.SetInt("currentLevel", -1);

            // Check if playerScript is assigned
            if (playerScript != null)
            {
                // Set currentLevel
                playerScript.currentLevel = -1;
                PlayerPrefs.SetInt("currentLevel", playerScript.currentLevel);

                // Verify the value has been set
                Debug.Log("Current Level Now Set To " + PlayerPrefs.GetInt("currentLevel"));
            }
            else
            {
                Debug.LogError("PlayerScript not assigned to OnLaunchGame!");
            }

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
        else if (scene.name.Equals("Level 2"))
        {
            playerScript.isNormalDimension = true;
            playerScript.canSwitchDimensions = true;
            playerScript.currentLevel = 2;
            PlayerPrefs.SetInt("currentLevel", 2);
            PlayerPrefs.SetInt("currentLevel", 2);

            // Check if playerScript is assigned
            if (playerScript != null)
            {
                // Set currentLevel
                playerScript.currentLevel = 2;
                PlayerPrefs.SetInt("currentLevel", playerScript.currentLevel);

                // Verify the value has been set
                Debug.Log("Current Level Now Set To " + PlayerPrefs.GetInt("currentLevel"));
            }
            else
            {
                Debug.LogError("PlayerScript not assigned to OnLaunchGame!");
            }

        }
        else if (scene.name.Equals("Level 3"))
        {
            playerScript.isNormalDimension = true;
            playerScript.canSwitchDimensions = true;
            playerScript.currentLevel = 3;
            PlayerPrefs.SetInt("currentLevel", 3);
            PlayerPrefs.SetInt("currentLevel", 3);

            // Check if playerScript is assigned
            if (playerScript != null)
            {
                // Set currentLevel
                playerScript.currentLevel = 3;
                PlayerPrefs.SetInt("currentLevel", playerScript.currentLevel);

                // Verify the value has been set
                Debug.Log("Current Level Now Set To " + PlayerPrefs.GetInt("currentLevel"));
            }
            else
            {
                Debug.LogError("PlayerScript not assigned to OnLaunchGame!");
            }

        }
        else if (scene.name.Equals("Level 4"))
        {
            playerScript.isNormalDimension = true;
            playerScript.canSwitchDimensions = true;
            playerScript.currentLevel = 4;
            PlayerPrefs.SetInt("currentLevel", 4);
            PlayerPrefs.SetInt("currentLevel", 4);

            // Check if playerScript is assigned
            if (playerScript != null)
            {
                // Set currentLevel
                playerScript.currentLevel = 4;
                PlayerPrefs.SetInt("currentLevel", playerScript.currentLevel);

                // Verify the value has been set
                Debug.Log("Current Level Now Set To " + PlayerPrefs.GetInt("currentLevel"));
            }
            else
            {
                Debug.LogError("PlayerScript not assigned to OnLaunchGame!");
            }

        }
        else if (scene.name.Equals("Zone1_Level5"))
        {
            playerScript.isNormalDimension = true;
            playerScript.canSwitchDimensions = true;
            playerScript.currentLevel = 5;
            PlayerPrefs.SetInt("currentLevel", 5);
            PlayerPrefs.SetInt("currentLevel", 5);

            // Check if playerScript is assigned
            if (playerScript != null)
            {
                // Set currentLevel
                playerScript.currentLevel = 5;
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
