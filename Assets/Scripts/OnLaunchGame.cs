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
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    private void OnSceneLoadedTwo(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals("StartMenu"))
        {
            playerScript.currentLevel = -6;
            PlayerPrefs.SetInt("currentLevel", playerScript.currentLevel);
        }
        else if (scene.name.Equals("Tutorial"))
        {
            GameObject.FindWithTag("NormalDimensionTutorial").SetActive(true);
            GameObject.FindWithTag("InvertedDimensionTutorial").SetActive(false);
            playerScript.isNormalDimension = true;
            playerScript.canSwitchDimensions = true;
            PlayerPrefs.SetInt("currentLevel", 0);
            Debug.Log("isNormalDimension set to: " + PlayerPrefs.GetInt("isNormalDimension"));
            Debug.Log("canSwitchDimensions set to: " + PlayerPrefs.GetInt("canSwitchDimensions"));

        }
    }
}
