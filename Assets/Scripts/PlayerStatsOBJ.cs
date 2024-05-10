using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsOBJ : MonoBehaviour
{
    GameObject Player;
    PlayerScript playerscript;
    int PlayerHealth, PlayerMaxHealth;
    int Oxygen, OxygenMax;
    int Ammo, ReserveAmmo;




    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerscript = Player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerPrefs.SetInt("PlayerHealth",playerscript.Health);
       
        
    }

    
}
