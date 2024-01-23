using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference to ScriptA
    public GroundCheck groundCheck;

    public GameObject player;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravityScale = 9.8f;

    private bool facingLeft = false;
    public bool isInvertReady = true;
    public float InvertCooldownTime = 0.5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Check the direction of gravity
        float gravityDirection = Mathf.Sign(rb.gravityScale);

        // Adjust movement based on gravity direction
        movement.x *= gravityDirection;

        rb.velocity = movement;

        // Flip the player's sprite if moving left
        Flip(horizontalInput);

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && groundCheck.isGrounded == true)
        {
            Jump();
        }

        // Invert gravity and rotate camera
        if (Input.GetKeyDown(KeyCode.Space) && isInvertReady == true && groundCheck.isGrounded == true)
        {
            StartCoroutine(InvertCooldown());
        }
    }

    void Jump()
    {
        // Check the direction of gravity
        float gravityDirection = Mathf.Sign(rb.gravityScale);

        // Apply force based on gravity direction
        rb.velocity = new Vector2(rb.velocity.x, jumpForce * gravityDirection);
    }

    void Flip(float horizontalInput)
    {
        // If moving left and facing right or moving right and facing left, flip the sprite
        if ((horizontalInput < 0 && !facingLeft) || (horizontalInput > 0 && facingLeft))
        {
            facingLeft = !facingLeft;

            // Flip the sprite by adjusting the scale
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }

    void InvertGravity()
    {
        rb.gravityScale *= -1;

        //Flips Camera
        CameraFlip();
    }

    void CameraFlip()
    {
        player.transform.Rotate(0f, 0f, 180f);
    }

    IEnumerator InvertCooldown()
    {
        isInvertReady = false;
        InvertGravity();
        //Debug.Log("Cooldown starting");

        // Wait for the cooldown to finish
        yield return new WaitForSeconds(InvertCooldownTime);

        //Debug.Log("Cooldown ended");
        isInvertReady = true;
    }
}
