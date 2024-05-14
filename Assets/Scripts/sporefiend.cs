using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class sporefiend : MonoBehaviour
{

    GameObject player;
    SpriteRenderer sprite;
    public int nextID;
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
    bool dead;

    public AudioClip DeathGrowl;
    public AudioClip AletGrowl;

    // Start is called before the first frame update



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("sadsad");
        if (collision.transform.CompareTag("PlayerBullet"))
        {
            StartCoroutine(Damage(10));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerBullet"))
        {
            StartCoroutine(Damage(10));
        }
       
    }



    private void Start()

    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        sprite = GetComponent<SpriteRenderer>();

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

            if (rb.velocity.x != 0)
                animator.SetInteger("Velocity", 1);

            if (rb.velocity.x > 0)
            {
                sprite.flipX = false;
            }
            else if (rb.velocity.x < 0)
            {
                sprite.flipX = true;

            }


            Debug.Log(playerinrange);

            Debug.Log(playerinrange);

            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < 4 && playerinrange)
            {
                seenplayer = true;
                isChasingPlayer = true;

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
        }

    }




    void chaseplayer()
    {

        speed *= 1.5f;
        //Vector2 direction = player.transform.position - transform.position;

        float Xdirection = player.transform.position.x - transform.position.x;
        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);


        rb.velocity=new Vector3(Xdirection,rb.velocity.y,0);


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
            rb.velocity = new Vector3(-1 * speed, rb.velocity.y,0) ;

            // transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }


    void Death()
    {

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
