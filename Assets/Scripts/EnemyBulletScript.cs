using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour

{
   public  GameObject turret;
    public GameObject player;
    private Rigidbody2D rb;
    
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized* force;

       
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("asdasd");
        
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().Health -= 20;
            collision.gameObject.GetComponent<PlayerScript>().damaged=true;
            Destroy(this.gameObject);
        }
     
        {
            if (collision != null)
            {
                
                if (collision != turret) { } 
            }
        }
        
    }
}
