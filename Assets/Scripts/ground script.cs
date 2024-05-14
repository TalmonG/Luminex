using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundscript : MonoBehaviour
{
    bool floor;
    EnemyAiScript juggernautscript;
    GameObject player;
    public float speed;
    bool seenplayer;




    // Start is called before the first frame update
    void Start()
    {
 
    }
    
    

    

    

    // Update is called once per frame
    void Update()
    {

       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {         

            if (collision.CompareTag("Juggernaut"))
            {

            
                Debug.Log("hitedge");

                juggernautscript.HitCollider = this.gameObject;
                juggernautscript.isChasingPlayer = false;
                juggernautscript.ReachedEdge = true;
                juggernautscript.left_right *= -1;

            }

            if (collision.CompareTag("Sporefiend"))
            {
                collision.gameObject.GetComponent<sporefiend>().HitCollider = this.gameObject;
                collision.gameObject.GetComponent<sporefiend>().isChasingPlayer = false;
                collision.gameObject.GetComponent<sporefiend>().ReachedEdge = true;
                collision.gameObject.GetComponent<sporefiend>().left_right *= -1;
            }
            
        }

        
    }


}
