using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public GameObject[] Points;
    bool towardspoint1,towardspoint2;
    Rigidbody2D rb;
    int direction=1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        towardspoint1=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (towardspoint1)
        {
            rb.velocity = (Points[0].transform.position - transform.position).normalized*2;
        }
        if (Vector3.Distance(transform.position, Points[0].transform.position) <1)
        {
            towardspoint1 = false;
            towardspoint2 = true;
        }
        if (towardspoint2)
        {
            rb.velocity = (Points[1].transform.position-transform.position).normalized*2;

        }
        if (Vector3.Distance(transform.position, Points[1].transform.position) < 1)
        {
            towardspoint1 = true;
            towardspoint2 = false;
        }
    }
}
