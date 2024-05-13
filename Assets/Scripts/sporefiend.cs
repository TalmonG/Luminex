using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class sporefiend : MonoBehaviour
{

    GameObject player;
    public List<Transform> points;
    public int nextID;
    int idchangeValue = 1;
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

    // Start is called before the first frame update

    private void Reset()
    {
    

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
        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }



    private void Start()

    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        TargetCollider = Colliders[1];

    }

    // Update is called once per frame
    void Update()
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

        //Debug.Log(HitCollider.gameObject.name);

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

        Debug.Log(TargetCollider.name);

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



    
    }




    void chaseplayer()
    {

        Vector2 direction = player.transform.position - transform.position;
        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);


        rb.velocity=direction.normalized;


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
}
