using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybeahviour : MonoBehaviour
{
    private GameObject Player;
    public float speed;
    private float dist;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
      
    }

}
