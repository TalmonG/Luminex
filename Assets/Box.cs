using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Box : MonoBehaviour
{
    GameObject player;
    public GameObject laser;
    public GameObject laserSpawn;
    bool playerinrange;
    float timer;

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
    // Start is called before the first frame update
    void Start()
    {
      
    }
    void shoot()
    {
        Instantiate(laser, laserSpawn.transform.position, Quaternion.identity);
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
