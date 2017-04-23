using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour {

    private float speed = 3f;
    
    private Rigidbody2D rb2d;
    private Vector2 curVel;
    private SpriteRenderer renderer;

    public bool isJumping = false;
    private bool isGrounded = true;
    public bool isKnocked = false;
    private bool atDoor = false;
    private bool atBackDoor = false;

    private Animator ani;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public float up;    

    void Start()
    {       
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        curVel = rb2d.velocity;
        renderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            renderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            renderer.flipX = false;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            isJumping = true;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(atDoor)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if(atBackDoor)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
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

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            ani.SetBool("CharacterRunning", true);
            moveVelocity = Vector3.left;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            ani.SetBool("CharacterRunning", true);
            moveVelocity = Vector3.right;
        }
        else
        {
            ani.SetBool("CharacterRunning", false);
        }

        transform.position += moveVelocity * speed * Time.deltaTime;
    }

    void jump()
    {
        if (!isJumping)
            return;


        ani.SetBool("CharacterJump", true);
        rb2d.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, 10);
        rb2d.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
              
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UpPoint" && Input.GetAxisRaw("Horizontal") < 0)
            transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y + up, -1);

        if (collision.gameObject.tag == "Portal")
            atDoor = true;
        else if (collision.gameObject.tag == "BackPortal")
            atBackDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal")
            atDoor = false;
        else if (collision.gameObject.tag == "BackPortal")
            atBackDoor = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            ani.SetBool("CharacterJump", false);
    }
}
