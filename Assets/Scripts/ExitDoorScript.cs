using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class ExitDoorScript : MonoBehaviour
{
    public PlayerScript playerScript;
    GameObject Player;
    public bool PlayerinFront;

    public int currentLevelToSet;
    public string levelToLoad;
    public TextMeshProUGUI aetheriumText;

    Animator DoorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        DoorAnimator = GetComponent<Animator>();
        
        GameObject aetheriumTextObject = GameObject.FindWithTag("AetheriumText");
        aetheriumText = aetheriumTextObject.GetComponent<TextMeshProUGUI>();
        SetAetheriumCoinText();
    }

    public void SetAetheriumCoinText()
    {
        // Increment the count of aetherium coins

        // Update the text to display "Aetherium: <count>"
        aetheriumText.text = "Aetherium: " + playerScript.aetheriumCoinCount.ToString();

        Debug.Log("Aetherium count updated: " + playerScript.aetheriumCoinCount);
        playerScript.SavePlayerStats();
        Debug.Log("HERE BOI");
    }

    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerinFront)
        {
            playerScript.currentLevel = currentLevelToSet;
            Debug.Log(playerScript.currentLevel);
            DoorAnimator.SetTrigger("OnOpen");
            // PLEASE ADD A WAIT FOR ANIMATION TO END HERE
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerinFront = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("aetheriumCoinCount", playerScript.aetheriumCoinCount);
        Debug.Log("Player Now Has " + PlayerPrefs.GetInt("aetheriumCoinCount") + " Coins");

        if (collision.CompareTag("Player"))
        {
            PlayerinFront = true;
        }
    }
}
