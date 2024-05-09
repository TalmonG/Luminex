using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject HUDCanvasPrefab;
    public GameObject playerPrefab;
    public GameObject managerPrefab;

    private GameObject HUDCanvas;
    private GameObject player;
    private GameObject manager;

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadTutorial()
    {
        // Load tutorial scene
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadLevel(string levelName)
    {
        // Load level scene
        SceneManager.LoadScene(levelName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if not in main menu or options menu, then instantiate HUDCanvas
        if (!scene.name.Equals("MainMenu") && !scene.name.Equals("OptionsMenu") && HUDCanvas == null)
        {
            HUDCanvas = Instantiate(HUDCanvasPrefab);
        }

        // Instantiate player if not already present
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                player = Instantiate(playerPrefab);
            }
        }

        // Instantiate manager if not already present
        if (manager == null)
        {
            manager = GameObject.FindWithTag("Managers");
            if (manager == null)
            {
                manager = Instantiate(managerPrefab);
            }
        }
    }

    // Additional methods to manage game state, etc.
}
