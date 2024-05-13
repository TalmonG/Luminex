using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.Burst.CompilerServices;
using UnityEditor.UIElements;
using UnityEngine;

public class Turret : MonoBehaviour
{
    GameObject Player;
    LayerMask LayerMask;
    public GameObject bullet;
    public GameObject bulletPos;
    private float timer;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
       //LayerMask = GameObject.Find("Platform").layer;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(this.gameObject);
        }

        Vector3 direction = Player.transform.position - transform.position;


        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 30);


       // if (hit.transform.gameObject == Player.gameObject)
       // {
            Quaternion lookrotation = Quaternion.LookRotation(Vector3.forward, direction);
            lookrotation.eulerAngles += Vector3.forward * -90;
            transform.rotation = lookrotation;

       // }


        if (Player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else { transform.localScale = new Vector3(1, -1, 1); }
        Debug.DrawRay(transform.position, direction);

        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer > 1)
        {
            timer = 0;
            shoot();
        }
        

        
    }
    void shoot() {
        Instantiate(bullet, bulletPos.transform.position, Quaternion.identity); 

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("sadsad");
        if (collision.transform.CompareTag("PlayerBullet"))
        {
            health -= 10;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerBullet"))
        {
            health -= 10;
        }
        
    }
    


}