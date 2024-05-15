using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum CollectableType
{
    //Ammo,
    AetheriumCoin,
    DoubleDamage,
    Fuel,
    JetPack,
    PurpleGem,
    SilverCoin,
    UpgradeToken,
    GravityPickup
}
public class Collectables : MonoBehaviour
{
    // Referencing
    //public Weapon weapon;
    public PlayerScript playerScript;

    public GameObject Player;
    GameObject canvas;

    public TextMeshProUGUI aetheriumText;

    public CollectableType collectableType;

    /*public void AddAmmoToCurrentWeapon()
    {
        if (weapon != null)
        {
            int currentWeaponIndex = weapon.CurrentWeapon;

            // Add 20 ammo to the current weapon's reserve ammo
            weapon.Ammo[currentWeaponIndex, 1] += 20;
            Destroy(gameObject);

        }
    }*/

    public void AddAetheriumCoin()
    {
        // Increment the count of aetherium coins
        playerScript.aetheriumCoinCount++;

        // Update the text to display "Aetherium: <count>"
        aetheriumText.text = "Aetherium: " + playerScript.aetheriumCoinCount.ToString();

        Debug.Log("Aetherium count updated: " + playerScript.aetheriumCoinCount);
        playerScript.SavePlayerStats();
        Destroy(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        //canvas = GameObject.Find("Canvas");

        Player = GameObject.FindWithTag("Player");

        //aetheriumText = GameObject.FindWithTag("AetheriumText").GetComponent<TextMeshProUGUI>();
        Player = GameObject.FindWithTag("Player");
        GameObject aetheriumTextObject = GameObject.FindWithTag("AetheriumText");

        aetheriumText = aetheriumTextObject.GetComponent<TextMeshProUGUI>();

        /*if (aetheriumTextObject != null)
        {
            aetheriumText = aetheriumTextObject.GetComponent<TextMeshProUGUI>();
            Debug.Log("AetheriumText found: " + aetheriumTextObject.name);
        }
        else
        {
            Debug.LogError("AetheriumText not found!");
        }*/



        // aetheriumText = canvas.transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            if(this.gameObject.CompareTag("AetheriumCoin"))
            {
                AddAetheriumCoin();
            }
            else if (this.gameObject.CompareTag("GravityPickup"))
            {
                collision.GetComponent<PlayerScript>().canGRotate=true;

                Destroy(this.gameObject);
            }
        }
    }
}
