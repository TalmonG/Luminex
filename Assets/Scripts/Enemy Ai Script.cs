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
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 4)
        {
            seenplayer = true;
          
            
        }

        
       
        if (seenplayer){
            chaseplayer();

        }
        else { MoveToNextPoint(); }
    }
    void MoveToNextPoint()
    {
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
        
    }
        
    
    void chaseplayer()
    {
        
        Vector2 direction = player.transform.position - transform.position;
        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        
        
            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        
    }
   
}
