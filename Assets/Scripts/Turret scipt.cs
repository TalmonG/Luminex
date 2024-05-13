using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turretscipt : MonoBehaviour
{
    Transform Untagged;
    float dist;
    // Start is called before the first frame update
    void Start()
    {
        Untagged = GameObject.FindGameObjectWithTag("Untagged").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
