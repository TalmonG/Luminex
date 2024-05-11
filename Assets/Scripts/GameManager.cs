using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject HUDCanvasPrefab;
    //public GameObject playerPrefab;
    public GameObject managerPrefab;

    private GameObject HUDCanvas;
    //private GameObject player;
    private GameObject manager;

    private void Awake()
    {
        // Singleton pattern
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    /*public void LoadTutorial()
    {
        // Load tutorial scene
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadLevel(string levelName)
    {
        // Load level scene
        SceneManager.LoadScene(levelName);
    }*/

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If in StartMenu and no manager then instantiate manager
        if (scene.name.Equals("StartMenu") && manager == null)
        {
            manager = Instantiate(managerPrefab);
        }

        // If in StartMenu and no manager then instantiate manager
        if (scene.name.Equals("Options_Audio") && manager == null)
        {
            manager = Instantiate(managerPrefab);
        }

        // If in StartMenu and no manager then instantiate manager
        if (scene.name.Equals("Options_Controls") && manager == null)
        {
            manager = Instantiate(managerPrefab);
        }

        // If in StartMenu and no manager then instantiate manager
        if (scene.name.Equals("Options_Graphics") && manager == null)
        {
            manager = Instantiate(managerPrefab);
        }


        // If not in main menu or options menu, instantiate HUDCanvas
        if (scene.name.Equals("Credits") && manager == null)
        {
            manager = Instantiate(manager);
        }

        // Instantiate player if not already present in "Tutorial" scene
        if (scene.name.Equals("HUB Level"))
        {
            /*if (player == null)
            {
                player = GameObject.FindWithTag("Player");
                if (player == null)
                {
                    player = Instantiate(playerPrefab);
                }
            }*/

            // Instantiate HUDCanvas if not already present
            if (HUDCanvas == null)
            {
                HUDCanvas = Instantiate(HUDCanvasPrefab);
            }

            // Instantiate HUDCanvas if not already present
            if (manager == null)
            {
                manager = Instantiate(managerPrefab);
            }
        }

        // Instantiate player if not already present in "Tutorial" scene
        if (scene.name.Equals("Tutorial"))
        {
            /*if (player == null)
            {
                player = GameObject.FindWithTag("Player");
                if (player == null)
                {
                    player = Instantiate(playerPrefab);
                }
            }*/

            // Instantiate HUDCanvas if not already present
            if (HUDCanvas == null)
            {
                HUDCanvas = Instantiate(HUDCanvasPrefab);
            }

            // Instantiate HUDCanvas if not already present
            if (manager == null)
            {
                manager = Instantiate(managerPrefab);
            }
        }

        

        
    }

    // Additional methods to manage game state, etc.
}
