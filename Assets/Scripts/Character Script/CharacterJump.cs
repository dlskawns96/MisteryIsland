using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{

    private Rigidbody2D rb2d;

    public float jumpForce = 10000f;
    public float jumpTime = 0.05f;
    public float jumpTimeCounter;

    public bool grounded;
    public LayerMask whatIsGround;
    public bool stoppedJumping;

    public Transform groundCheck;
    public float groundCheckRadius;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }
    }

    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (grounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

                stoppedJumping = false;
            }
        }

        if (Input.GetKey(KeyCode.LeftAlt) && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
    }
}
