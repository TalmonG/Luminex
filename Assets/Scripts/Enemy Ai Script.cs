using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAiScript : MonoBehaviour
{

    GameObject player;
    SpriteRenderer sprite;
    Animator animator;
    public float speed = 2;
    public int left_right = 1;
    public bool isChasingPlayer = false;
    public bool ReachedEdge = false;
    public bool playerinrange;
    public int health;
    public GameObject TargetCollider;
    public GameObject HitCollider;
    public GameObject[] Colliders;
    public float ShootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    private float distance;
    bool seenplayer;
    Rigidbody2D rb;
    public bool dead;

    public bool InRangeOfMelee;
    bool alerted;
    bool HasAttacked;

    AudioSource audioSource;
    public AudioClip DeathGrowl;
    public AudioClip AlertGrowl;
    public AudioClip SlashSound;
    int i = 0;
    // Start is called before the first frame update



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("PlayerBullet") && !dead)
        {
            StartCoroutine(Damage(10));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerBullet") && !dead)
        {
            StartCoroutine(Damage(5));
            i += 5;
        }

    }



    private void Start()

    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        sprite = GetComponent<SpriteRenderer>();

        audioSource = GetComponent<AudioSource>();

        TargetCollider = Colliders[1];



    }

    // Update is called once per frame
    void Update()
    {

        if (!dead)
        {

            if (HitCollider != null)
            {
                if (HitCollider.CompareTag("LeftCollider"))
                {
                    TargetCollider = Colliders[1];
                }
                if (HitCollider.CompareTag("RightCollider"))
                {
                    TargetCollider = Colliders[0];
                }
            }

           // if (rb.velocity.x != 0)
               // animator.SetInteger("Velocity", 1);

            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }
            Debug.Log(TargetCollider);


            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < 1 && playerinrange)
            {
                seenplayer = true;
                isChasingPlayer = true;

                alerted = true;

            }

            if (alerted)
            {
                //audioSource.clip = AlertGrowl;
                //  audioSource.Play();
                // alerted=false;
            }

            if (!playerinrange)
            {
                isChasingPlayer = false;
            }

            //Debug.Log(TargetCollider.name);

            if (isChasingPlayer)
            {
                chaseplayer();

            }
            if (ReachedEdge)
            {
                patrol();
                ReachedEdge = false;
            }

            if (!isChasingPlayer) { patrol(); }


            if (health <= 0)
            {
                Death();
            }
            if (InRangeOfMelee && !HasAttacked)
            {
                HasAttacked = true;
                StartCoroutine(MeleeAttack());
            }


        }


        if (dead)
        {
            if (GameObject.FindGameObjectWithTag("FrictionCollider").gameObject.GetComponent<Collider2D>() != null)
            {
                Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("FrictionCollider").gameObject.GetComponent<Collider2D>(), true);
            }
            Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), true);


            if (Vector3.Distance(transform.position, player.transform.position) > 20)
            {
                Destroy(this.gameObject);
            }
        }


    }




    void chaseplayer()
    {

        speed = 2.3f;

        float Xdirection = player.transform.position.x - transform.position.x;


        rb.velocity = new Vector3(Xdirection * speed, rb.velocity.y, 0);


    }


    void patrol()
    {
        if (TargetCollider.CompareTag("RightCollider"))
        {

            rb.velocity = new Vector3(1 * speed, rb.velocity.y, 0);

            // transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (TargetCollider.CompareTag("LeftCollider"))
        {
            rb.velocity = new Vector3(-1 * speed, rb.velocity.y, 0);

            // transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }



    IEnumerator MeleeAttack()
    {
        animator.SetTrigger("Slash");

        audioSource.clip = SlashSound;
        if (audioSource.isPlaying == false)
            audioSource.Play();

        StartCoroutine(player.GetComponent<PlayerScript>().Damage(10));


        yield return new WaitForSeconds(1.5f);
        HasAttacked = false;

    }

    void Death()
    {
        dead = true;

        animator.SetBool("Dead", true);

        rb.velocity = new Vector3(0, rb.velocity.y, 0);



    }

    public IEnumerator Damage(int damage)
    {
        health -= damage;

        sprite.color = Color.red;

        yield return new WaitForSeconds(0.3f);

        sprite.color = Color.white;

        yield return null;
    }

}
