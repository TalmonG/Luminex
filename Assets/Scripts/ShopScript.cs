using System.Collections;
using System.Collections.Generic;
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
    private int Chrono = 10000;
    bool infront;

    void Start()
    {
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
    }

    void Update()
    {
        if(infront&& Input.GetKeyDown(KeyCode.E)) {
            Time.timeScale = 0;
            Debug.Log("sss");
            ShopCanvas.SetActive(true);
            itemShop.SetActive(true);
            HealthShop.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            Time.timeScale = 1;
            ShopCanvas.SetActive(false);
            itemShop.SetActive(false);
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

    public void onClickPistolBullet()
    {
        if(Chrono >= items["PistolBullet"])
        {
            pistolbullets += 20;
            Chrono -= items["PistolBullet"];
            audioSource.Play();
        }
    }
    public void onClickRifleBullet()
    {
        if (Chrono >= items["RifleBullet"])
        {
            RifleBullets += 24;
            Chrono -= items["RifleBullet"];
            audioSource.Play();
        }
    }
    public void onClickUpgradeToken()
    {
        if (Chrono >= items["UpgradeToken"])
        {
            UpgradeToken += 1;
            Chrono -= items["UpgradeToken"];
            audioSource.Play();
        }
    }
    public void onClickJetpackFuel()
    {
        if (Chrono >= items["JetpackFuel"])
        {
            JetpackFuel += 1;
            Chrono -= items["JetpackFuel"];
            audioSource.Play();
        }
    }
    public void onClickBanadage()
    {
        if (Chrono >= items["Bandage"])
        {
            Bandage += 1;
            Chrono -= items["Banadage"];
            audioSource.Play();
        }
    }
    public void onClickMedKit()
    {
        if (Chrono >= items["MedKit"])
        {
            MedKit += 1;
            Chrono -= items["MedKit"];
            audioSource.Play();
        }
    }
    public void onClickSyringe()
    {
        if (Chrono >= items["Syringe"])
        {
            Syringe += 1;
            Chrono -= items["Syringe"];
            audioSource.Play();
        }
    }
    public void onClickSteroids()
    {
        if (Chrono >= items["Steroids"])
        {
            Steroids += 1;
            Chrono -= items["Steroids"];
            audioSource.Play();
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

}
