using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ExitDoorScript : MonoBehaviour
{
    GameObject Player;
    bool PlayerinFront;

    Animator DoorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Player = GlobalReferenceScript.instance.Player;
        DoorAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerinFront)
        {
            DoorAnimator.SetTrigger("OnOpen");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject == Player)
            {
                PlayerinFront=false;
                
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject == Player)
            {
                PlayerinFront = true;

            }
        }
    }

     void TriggerLevelTransition(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }


}
