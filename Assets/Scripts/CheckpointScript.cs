using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{

    GameObject Player;
    public GameObject Pistol;
    public GameObject BR;
    public GameObject Shotgun;
    public GameObject GL;
    GameObject Text;
    bool infront;
    bool activated;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Text = transform.GetChild(0).gameObject;
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(PlayerPrefs.GetInt("PistolAmmo"));

        // Debug.Log( BR.GetComponent<Weapon>().Ammo[1,0]);#

        if (infront && Input.GetKeyDown(KeyCode.E) && !activated)
        {
            StartCoroutine(SaveCheckpoint());
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {

                infront = true;


            }



        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {

                infront = false;


            }



        }
    }

    IEnumerator SaveCheckpoint()
    {
        activated = true;
        Text.SetActive(true);
        Player.GetComponent<PlayerScript>().SavePlayerStats();

        Pistol.GetComponent<Weapon>().SaveWeaponPrefs();
        BR.GetComponent<Weapon>().SaveWeaponPrefs();
        Shotgun.GetComponent<Weapon>().SaveWeaponPrefs();
        GL.GetComponent<Weapon>().SaveWeaponPrefs();

        yield return new WaitForSeconds(3);

        Text.SetActive(false);
    }

}
