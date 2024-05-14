using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    Rigidbody2D rb;
    public int speed =5;
    GameObject Player;
    public int gravityScale;
    int bounces;
    public GameObject BulletImpactEffect;
    float lifetime=1.5f;
    public  GameObject ExplosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        /* Player = GameObject.Find("Player");
         Rigidbody2D playerrb = Player.GetComponent<Rigidbody2D>();
         Vector3 PlayerVelocity = playerrb.velocity;*/

        Player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        rb.velocity= transform.right*speed;

        rb.gravityScale = gravityScale;
       // Debug.Log(PlayerVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,Player.transform.position)>50){ Destroy(this.gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("ground"))
            {
               GameObject impact = Instantiate(BulletImpactEffect, transform.position, Quaternion.identity);

               // impact.GetComponent<ParticleSystem>().enableEmission = false;
                Destroy(impact,0.5f);

                Destroy(this.gameObject);
            }
            else if ((collision.CompareTag("Sporefiend") || collision.CompareTag("Juggernaut")))
            {
                if (collision.GetComponent<sporefiend>().dead == false)
                {
                   

                    Destroy(this.gameObject);
                }

            }


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
            StartCoroutine(Life());
        
    }

    IEnumerator Life()
    {
        yield return new WaitForSeconds(lifetime);
        GameObject Explosion=Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);

        Explosion.GetComponent<AudioSource>().Play();

        
        Destroy(Explosion, 0.8f);
        Destroy(this.gameObject);
    }
}
