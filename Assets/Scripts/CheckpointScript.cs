using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public GameObject Pistol;
    public GameObject BR;
    public GameObject Shotgun;
    public GameObject GL;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("PistolAmmo"));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.GetComponent<PlayerScript>().SavePlayerStats();



                // collision.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Weapon>().SaveWeaponPrefs();
                // collision.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Weapon>().SaveWeaponPrefs();
                // collision.transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<Weapon>().SaveWeaponPrefs();
                // collision.transform.GetChild(0).transform.GetChild(3).gameObject.GetComponent<Weapon>().SaveWeaponPrefs();#

                Pistol.GetComponent<Weapon>().SaveWeaponPrefs();
                BR.GetComponent<Weapon>().SaveWeaponPrefs();
                Shotgun.GetComponent<Weapon>().SaveWeaponPrefs();
                GL.GetComponent<Weapon>().SaveWeaponPrefs();

            }

           

        }
    }
}
