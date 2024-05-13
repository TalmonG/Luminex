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
    public List<Transform> points;
    public int nextID;
    int idchangeValue = 1;
    public float speed = 2;
    public int left_right = 1;
    public bool isChasingPlayer=false;
    public bool ReachedEdge=false;
    public bool playerinrange;
    public GameObject TargetCollider;
    public GameObject HitCollider;
    public GameObject[] Colliders;

    private float distance;
    bool seenplayer;

    // Start is called before the first frame update
    
    private void Reset()
    {
       Init();

    }
    private void Init()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        GameObject root = new GameObject(name + "_Root");
        root.transform.position = transform.position;
        transform.SetParent(root.transform);
        GameObject waypoints = new GameObject("Waypoints");
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        GameObject p1 = new GameObject("Point1");p1.transform.SetParent(waypoints.transform);p1.transform.position = Vector3.zero;
        GameObject p2 = new GameObject("Point2");p2.transform.SetParent(waypoints.transform);p2.transform.position = Vector3.zero;  
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);


    }


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        TargetCollider = Colliders[1];

    }

    // Update is called once per frame
    void Update()
    {
        if(HitCollider != null)
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

        if (distance < 4&&playerinrange)
        {
            seenplayer = true;
           isChasingPlayer = true;
            
        }

        if (!playerinrange)
        {
            isChasingPlayer= false;
        }

        Debug.Log(TargetCollider.name);

        if (isChasingPlayer){
            chaseplayer();

        }
        if (ReachedEdge)
        {
            patrol();
           ReachedEdge = false;
        }
    
        if (!isChasingPlayer) { patrol(); }

       // else { MoveToNextPoint(); }
    }
    void MoveToNextPoint()
    {/*
        Transform goalPoint = points[nextID];
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale =new Vector3(1, 1, 1);
        transform.position = Vector2.MoveTowards(transform.position,goalPoint.position,speed*Time.deltaTime);
        if (Vector2.Distance(transform.position, goalPoint.position)<0.2f)
        {
            if (nextID == points.Count - 1)
                idchangeValue = -1;
            if (nextID == 0)
                idchangeValue = 1;
            nextID += idchangeValue;
        }
        */
    }

        
    
    void chaseplayer()
    {
        
        Vector2 direction = player.transform.position - transform.position;
        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        
        
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

    }
   

    void patrol()
    {
        if (TargetCollider.CompareTag("RightCollider"))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (TargetCollider.CompareTag("LeftCollider"))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

}
