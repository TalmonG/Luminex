using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    private Dictionary<string,int> items = new Dictionary<string,int>();
    private GameObject Buttons;
    private int Chrono = 10000;

    void Start()
    {
        items.Add("UpgradeToken", 100);
        items.Add("PistolBullet", 5);
        items.Add("RifleBullet", 15);
        items.Add("JetpackFuel", 20);
        items.Add("Bandage", 3);
        items.Add("Medkit", 20);
        items.Add("Syringe",15 );
        items.Add("Steroids", 10);
    }

    void Update()
    {
        
    }

    public void onClickShopButtons()
    {
        if (GameObject.FindWithTag("PistolBulletShopButton"))
        {

        }
        else if (GameObject.FindWithTag("RifleBulletShopButton"))
        {

        }
        else if (GameObject.FindWithTag("UpgradeToken"))
        {

        }
        else if (GameObject.FindWithTag("RifleBulletShopButton"))
        {

        }
    }
}
