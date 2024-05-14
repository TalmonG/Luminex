using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerinRange : MonoBehaviour
{

    bool Playerinrange;
    EnemyAiScript juggernautscript;
    public GameObject LinkedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
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
            Debug.Log("dfsd");

            if (LinkedEnemy != null)

            {
                if (LinkedEnemy.gameObject.CompareTag("Sporefiend"))
                {
                    LinkedEnemy.gameObject.GetComponent<sporefiend>().playerinrange = true;
                }

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Playerinrange = false;
        


            if (LinkedEnemy != null)

            {
                if (LinkedEnemy.gameObject.CompareTag("Sporefiend"))
                {
                    LinkedEnemy.gameObject.GetComponent<sporefiend>().playerinrange = false;
                }

            }
        }
    }

}
