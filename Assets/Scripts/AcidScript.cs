using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidScript : MonoBehaviour
{
    bool alreadyDamaged;
    bool CollidingWithAcid=false;
    GameObject Collision;
     AudioSource audioSource;
    public AudioClip Radiationsound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CollidingWithAcid && !alreadyDamaged&& Collision.GetComponent<PlayerScript>().Health>0)
        {
            if (Collision.GetComponent<PlayerScript>()!=null)
            {
                alreadyDamaged = true;
                StartCoroutine(Collision.GetComponent<PlayerScript>().Damage(10));
                Invoke("EnableDamage", 0.5f);
            }
        }

        if (CollidingWithAcid)
        {
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }

        else
        {
            audioSource.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Collision = collision.gameObject;
            CollidingWithAcid=true;
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Collision = collision.gameObject;
            CollidingWithAcid = false;


        }
    }

    void EnableDamage()
    {
        alreadyDamaged = false;
    }

}
