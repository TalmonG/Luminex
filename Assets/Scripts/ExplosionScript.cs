using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

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
        if (collision.CompareTag("Sporefiend"))
        {
            StartCoroutine(collision.gameObject.GetComponent<sporefiend>().Damage(50));
        }
        else if (collision.CompareTag("Juggernaut"))
        {
            StartCoroutine(collision.gameObject.GetComponent<EnemyAiScript>().Damage(50));
        }
        else if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().damaged = true;
        }
    }
}
