using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-2 * Time.deltaTime, 0);

        if(transform.position.x < -9.6)
        {
            transform.position = new Vector3(9.6f, transform.position.y);
        }
    }
}
