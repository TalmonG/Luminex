using System.Collections;
using System.Collections.Generic;
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
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
      
    }

}
