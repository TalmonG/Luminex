using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    bool inrange;
    public bool locked;
    public Sprite OpenSprites;
    public Sprite lockedSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!locked)
        {

            if (inrange)
            {
                transform.GetChild(0).GetComponent<Animator>().SetBool("Inrange", true);
            }
            else
            {
                transform.GetChild(0).GetComponent<Animator>().SetBool("Inrange", false);

            }

        }
        else
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite= lockedSprite;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inrange = false;
        }
    }
}
