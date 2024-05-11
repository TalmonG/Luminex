using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ExitDoorScript : MonoBehaviour
{
    GameObject Player;
    public bool PlayerinFront;

    public string levelToLoad;

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
            SceneManager.LoadScene(levelToLoad);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerinFront = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerinFront = true;
        }
    }

     void TriggerLevelTransition(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }


}
