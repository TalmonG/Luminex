using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{
    float speed;
    public Transform target;
    bool floor;
    bool onground;
    public Rigidbody2D rb;
    Enemybeahviour enemybeahviour;
    public LayerMask groundlayer;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        enemybeahviour = transform.parent.transform.GetComponent<Enemybeahviour>();

        enemybeahviour.onground = onground;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("ground"))
            {
                onground= true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("ground"))
            {
                onground = false;
            }
        }
       
    }

}

