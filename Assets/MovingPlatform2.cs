using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform2 : MonoBehaviour
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
    {/*
        if(collision.gameObject==transform.parent.gameObject)
        transform.parent.GetComponent<MovingPlatform>().direction *= -1;*/
    }
}
