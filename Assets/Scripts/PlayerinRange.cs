using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerinRange : MonoBehaviour
{

    bool Playerinrange;
    EnemyAiScript juggernautscript;
   
    
    // Start is called before the first frame update
    void Start()
    {
        juggernautscript = GameObject.FindGameObjectWithTag("Juggernaut").transform.GetComponent<EnemyAiScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Playerinrange = true;
            juggernautscript.playerinrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Playerinrange = false;
            juggernautscript.playerinrange = false;
        }
    }

}
