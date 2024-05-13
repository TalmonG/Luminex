using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlatformscript : MonoBehaviour
{
    public float speed;
    public float rayDist;
    private bool movingRight;
    public Transform groundDetect;
    public bool collidertouchfloor;
   

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {/*
        RaycastHit2D GroundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayDist);
        if (GroundCheck.collider == false)
        {
            if (movingRight==true)
            {
                transform.eulerAngles = new Vector3(0, -160, 0);
                movingRight = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }*/
    }
}
