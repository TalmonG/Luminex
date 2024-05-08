using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    Ammo,
    BlueCoin,
    DoubleDamage,
    Fuel,
    JetPack,
    PurpleGem,
    SilverCoin,
    UpgradeToken
}
public class Collectables : MonoBehaviour
{
    // Referencing
    public Weapon weapon;

    public CollectableType collectableType;

    public void AddAmmoToCurrentWeapon()
    {
        if (weapon != null)
        {
            int currentWeaponIndex = weapon.CurrentWeapon;

            // Add 20 ammo to the current weapon's reserve ammo
            weapon.Ammo[currentWeaponIndex, 0] += 20;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddAmmoToCurrentWeapon();
        Destroy(gameObject);
    }
}
