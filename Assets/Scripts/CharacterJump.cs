using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float jumpForce = 5f;
    public float jumpTime = 0.25f;
    public float jumpTimeCounter;

    public bool grounded;
    public LayerMask whatIsGround;
    public bool stoppedJumping;

    public Transform groundCheck;
    public float groundCheckRadius;

    // Use this for initialization
    void Start () {

        rb2d = gameObject.GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;

        Debug.Log(jumpTimeCounter);
    }
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //if we are grounded...
        if (grounded)
        {
            //the jumpcounter is whatever we set jumptime to in the editor.
            jumpTimeCounter = jumpTime;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //and you are on the ground...
            if (grounded)
            {
                //jump!
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

                stoppedJumping = false;
            }
        }

        //if you keep holding down the mouse button...
        if (Input.GetKey(KeyCode.Space) && !stoppedJumping)
        {
            //and your counter hasn't reached zero...
            if (jumpTimeCounter > 0)
            {
                //keep jumping!

                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;

            }
        }


        //if you stop holding down the mouse button...
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //stop jumping and set your counter to zero.  The timer will reset once we touch the ground again in the update function.
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
    }
}
