using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemybeahviour : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public bool isChasing;
    public float chaseDistance;
    public Transform groundDetect;
    private bool movingRight = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        ChasePlayer();
        CheckGround();
    }

    private void ChasePlayer()
    {
        if (isChasing)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            if (direction.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);

            transform.position += direction * speed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, player.transform.position) < chaseDistance)
            isChasing = true;
        else
            isChasing = false;
    }

    private void CheckGround()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down);
        if (groundInfo.collider == null)
        {
            Flip();
        }
    }

    private void Flip()
    {
        movingRight = !movingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}


