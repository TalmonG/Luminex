using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundscript : MonoBehaviour
{
    bool floor;
    EnemyPlatformscript juggernautscript;
    GameObject player;
    public float speed;
    bool seenplayer;




    // Start is called before the first frame update
    void Start()
    {
        juggernautscript = GameObject.FindGameObjectWithTag("Juggernaut").transform.GetComponent<EnemyPlatformscript>();

        player = GameObject.FindGameObjectWithTag("Player");
      

    }
    
    

    

    

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("ground"))
            {
                floor = true;   

            }

            if (collision.CompareTag("Juggernaut"))
            {
                Debug.Log("dist");

                juggernautscript.left_right *= -1;

            }
            
        }
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 4)
        {
            seenplayer = true;


        }



        if (seenplayer)
        {
            chaseplayer();

        }
        else { }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)

        {
            if (collision.gameObject.CompareTag("ground"))
            {
                floor = true;

            }

        }
    }
    void chaseplayer()
    {

        Vector2 direction = player.transform.position - transform.position;
        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);


        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

    }


}
