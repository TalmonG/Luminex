using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.UIElements;
using UnityEngine;

public class Turret : MonoBehaviour
{
    GameObject Player;
    LayerMask LayerMask;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        LayerMask = GameObject.Find("Platform").layer;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = Player.transform.position-transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 30);


        if (hit.transform.gameObject == Player) 
        {
            Quaternion lookrotation = Quaternion.LookRotation(Vector3.forward, direction);
            lookrotation.eulerAngles += Vector3.forward * -90;
            transform.rotation = lookrotation;
            Debug.Log("ss");

        }


        if (Player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else { transform.localScale = new Vector3(1, -1, 1); }
        Debug.DrawRay(transform.position,direction);
    }



}
