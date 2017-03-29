using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    public float speed = 100f;
    
    private Rigidbody2D rb2d;
    private Vector2 curVel;
    private SpriteRenderer renderer;
    private bool isJumping = false;
    private bool isGrounded = true;

    public bool isKnocked = false;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    void Start()
    {       
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        curVel = rb2d.velocity;
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            renderer.flipX = true;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            renderer.flipX = false;

        if (isGrounded && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            isJumping = true;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }

    void FixedUpdate()
    {
        if (!isKnocked)
        {
            move();
            jump();
        }
        else
        {
            StartCoroutine(waitKnocked());
        }
        
        /*
        if(!isKnocked)
        {
            curVel.x = Input.GetAxisRaw("Horizontal") * speed;
            rb2d.velocity = curVel;
        }
        else
        {
            StartCoroutine(waitKnocked());
            
        }*/
    }

    IEnumerator waitKnocked()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        isKnocked = false;
    }

    void move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal") < 0)
            moveVelocity = Vector3.left;
        else if(Input.GetAxisRaw("Horizontal") > 0)
            moveVelocity = Vector3.right;


        transform.position += moveVelocity * speed * Time.deltaTime;
    }

    void jump()
    {
        if (!isJumping)
            return;

        
        rb2d.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, 500);
        rb2d.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
              
    }
}
