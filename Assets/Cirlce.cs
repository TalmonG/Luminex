using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cirlce : MonoBehaviour
{
    bool playerinrange;
    float timer;
    GameObject player;
    public GameObject beam;
    public GameObject beamSpawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerinrange = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerinrange = false;

        }
    }
    void shoot()
    {
        Instantiate(beam, beamSpawn.transform.position, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerinrange)
        {

            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                shoot();
            }
        }
    }
   
}
