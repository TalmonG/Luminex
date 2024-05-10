/*using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemybeahviour : MonoBehaviour
{
    private GameObject Player;
    public float speed;
    private float dist;
    public Transform[] patrolPoints;
    public int patrolDestination;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;
    public bool onground; 
    public object PlayerTransformation { get; private set; }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (isChasing)
        {
            if(transform.position.x > Player.transform.position.x) 
            {
                transform.localScale = new Vector3(-1, 1, 1); 
                transform.position += Vector3.left * speed * Time.deltaTime;
                
            }
            if (transform.position.x < Player.transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.right * speed * Time.deltaTime;
            
            }
        }
        
        
            if (Vector3.Distance(transform.position, Player.transform.position) < chaseDistance) 
            {
            isChasing = true;
            }

        if (Vector3.Distance(transform.position, Player.transform.position) > chaseDistance)
        {
            isChasing = false;
        } 

        {

            /*if (patrolDestination == 0)
             {
                 transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, speed * Time.deltaTime);
                 if (Vector2.Distance(transform.position, patrolPoints[0].position) < .3f)
                 {

                     transform.localScale = new Vector3(1, 1, 1);
                     patrolDestination = 1;
                 }
             }
             if (patrolDestination == 1)
             {
                 transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, speed * Time.deltaTime);
                 if (Vector2.Distance(transform.position, patrolPoints[1].position) < .3f)
                 {

                     transform.localScale = new Vector3(-1, 1, 1);
                     patrolDestination = 0;
                 }
             }

            Mathf.PingPong(Time.deltaTime * speed, dist);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = true;
        }
    }
}
/*