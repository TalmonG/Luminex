using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollisionScript : MonoBehaviour
{
    public bool OnFloor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetBool("OnFloor",OnFloor);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("ground"))
            {
                OnFloor = true;

            }
           


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("ground"))
            {
                GameObject.FindWithTag("Player").GetComponent<Animator>().SetTrigger("OnLand");
                GameObject.FindWithTag("Player").GetComponent<Animator>().ResetTrigger("OnJump");

            }



        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            OnFloor = false;

        }
    }
}
