using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.Burst.CompilerServices;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.U2D;

public class Turret : MonoBehaviour
{
    GameObject Player;
    LayerMask LayerMask;
    public GameObject bullet;
    public GameObject bulletPos;
    private float timer;
    public int health;
    SpriteRenderer sprite;

    AudioSource audioSource;
    public AudioClip deathSound;
    public bool dead;

    Vector3 direction;
    Quaternion lookrotation;

    LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        sprite = transform.GetChild(0).transform.GetComponent<SpriteRenderer>();


        ground = GameObject.FindGameObjectWithTag("ground").gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {

            dead = true;
            StartCoroutine(Death());

        }
        if (Vector3.Distance(transform.position, Player.transform.position) < 20)
        {

            direction = Player.transform.position - transform.position;


            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 30);



            //  Debug.Log(hit.transform.position);

            // if (hit.transform.gameObject.CompareTag("Player"))
            //  {
            //Debug.Log("rayhit");

            lookrotation = Quaternion.LookRotation(Vector3.forward, direction);
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
            if (timer > 0.5f)
            {
                timer = 0;
                shoot();
            }
        }

    }
    void shoot()
    {




        Instantiate(bullet, bulletPos.transform.position, lookrotation);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
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


    IEnumerator Death()
    {
        // audioSource.clip = deathSound;
        //audioSource.Play();

        Destroy(this.gameObject);

        yield return null;
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