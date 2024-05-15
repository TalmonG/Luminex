using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    private Dictionary<string,int> items = new Dictionary<string,int>();
    public int pistolbullets = 30;
    public int RifleBullets = 12;
    public int UpgradeToken = 12;
    public int JetpackFuel = 12;
    public int Bandage = 12;
    public int MedKit = 12;
    public int Syringe = 12;
    public int Steroids = 12;
    public AudioSource audioSource;
    public GameObject itemShop;
    public GameObject HealthShop;
    public GameObject ShopCanvas;
    private int Aetherium = 10000;
    bool infront;

    GameObject Player;
    public TextMeshProUGUI aetheriumText;
    public PlayerScript playerScript;


    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Aetherium = playerScript.aetheriumCoinCount;
        GameObject aetheriumTextObject = GameObject.FindWithTag("AetheriumText");
        aetheriumText = aetheriumTextObject.GetComponent<TextMeshProUGUI>();
        SetAetheriumCoinTextShop();

        items.Add("UpgradeToken", 100);
        items.Add("PistolBullet", 5);
        items.Add("RifleBullet", 15);
        items.Add("JetpackFuel", 20);
        items.Add("Bandage", 3);
        items.Add("MedKit", 20);
        items.Add("Syringe",15 );
        items.Add("Steroids", 10);
        itemShop.SetActive(false);
        HealthShop.SetActive(false);
        ShopCanvas.SetActive(false);

        Debug.Log("RAHHHHHHHHHHHHH" + items["PistolBullet"]);
    }

    void SetAetheriumCoinTextShop()
    {
        // Increment the count of aetherium coins

        // Update the text to display "Aetherium: <count>"
        playerScript.aetheriumCoinCount = Aetherium;

        aetheriumText.text = "Aetherium: " + playerScript.aetheriumCoinCount.ToString();
        Debug.Log("Aetherium TEXT updated: " + playerScript.aetheriumCoinCount);
        Debug.Log("Aetherium count updated: " + playerScript.aetheriumCoinCount);
        playerScript.SavePlayerStats();
        playerScript.SetPlayerPrefs();
        Debug.Log("HERE BOI");
    }

    void Update()
    {
        GameObject aetheriumTextObject = GameObject.FindWithTag("AetheriumText");

        if(infront&& Input.GetKeyDown(KeyCode.E)) {
            Time.timeScale = 0;
            ShopCanvas.SetActive(true);
            itemShop.SetActive(true);
            HealthShop.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
          /*  Debug.Log("Player in");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E pressed");
                ShopCanvas.SetActive(true);
                itemShop.SetActive(true);
                HealthShop.SetActive(false);
            }*/

            infront = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        infront = false;
    }

    public void onClickPistolBullet()
    {
        if(Aetherium >= items["PistolBullet"])
        {
            pistolbullets += 20;
            Aetherium -= items["PistolBullet"];
            audioSource.Play();
            SetAetheriumCoinTextShop();
        }
    }
    public void onClickRifleBullet()
    {
        if (Aetherium >= items["RifleBullet"])
        {
            RifleBullets += 24;
            Aetherium -= items["RifleBullet"];
            audioSource.Play();
            SetAetheriumCoinTextShop();
        }
    }
    public void onClickUpgradeToken()
    {
        if (Aetherium >= items["UpgradeToken"])
        {
            UpgradeToken += 1;
            Aetherium -= items["UpgradeToken"];
            audioSource.Play();
            SetAetheriumCoinTextShop();
        }
    }
    public void onClickJetpackFuel()
    {
        if (Aetherium >= items["JetpackFuel"])
        {
            JetpackFuel += 1;
            Aetherium -= items["JetpackFuel"];
            audioSource.Play();
            SetAetheriumCoinTextShop();
        }
    }
    public void onClickBanadage()
    {
        if (Aetherium >= items["Bandage"])
        {
            Bandage += 1;
            Aetherium -= items["Banadage"];
            audioSource.Play();
            SetAetheriumCoinTextShop();
        }
    }
    public void onClickMedKit()
    {
        if (Aetherium >= items["MedKit"])
        {
            MedKit += 1;
            Aetherium -= items["MedKit"];
            audioSource.Play();
            SetAetheriumCoinTextShop();
        }
    }
    public void onClickSyringe()
    {
        if (Aetherium >= items["Syringe"])
        {
            Syringe += 1;
            Aetherium -= items["Syringe"];
            audioSource.Play();
            SetAetheriumCoinTextShop();
        }
    }
    public void onClickSteroids()
    {
        if (Aetherium >= items["Steroids"])
        {
            Steroids += 1;
            Aetherium -= items["Steroids"];
            audioSource.Play();
            SetAetheriumCoinTextShop();
        }
    }

    public void onClickHealthShop() 
    { 
        HealthShop.SetActive(true);
        itemShop.SetActive(false);
    }

    public void onClickItemShop()
    {
        itemShop.SetActive(true);
        HealthShop.SetActive(false);
    }

    public void onClickExit()
    {
        Time.timeScale = 1;
        ShopCanvas.SetActive(false);
        itemShop.SetActive(false);
        HealthShop.SetActive(false);
    }
}
