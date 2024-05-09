using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorScript : MonoBehaviour
{
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GlobalReferenceScript.instance.Player;

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject == Player)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("sss");

                }
            }
        }
    }

}
