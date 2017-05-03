using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{    
    private Rigidbody2D rb2d;
    private Animator ani;
    private Vector2 curVel;

    private float dest1, dest2;
    public float speed = 5f;
    private float jumpForce = 20f;   

    private bool isReturn = true;
    private bool isPatrol = true;
    public bool isLanded = true;
    public bool isJumped = false;
    private bool isBeating = false;
    private bool isWaiting = false;

    void Start()
    {
        dest1 = transform.position.x + 10;
        dest2 = transform.position.x - 10;
        rb2d = GetComponent<Rigidbody2D>();
        curVel = rb2d.velocity;
        curVel.x = speed;
        ani = GetComponent<Animator>();
        ani.SetBool("EnemyMoving", true);
    }

    void Update()
    {
        isBeating = GetComponent<Following>().isBeaten;
    }

    private void FixedUpdate()
    {
        if(!isBeating)
        {
            if (isPatrol)
            {
                if(!isWaiting)
                {                   
                    if (isReturn)
                        toDest2();
                    else
                        toDest1();
                }                                
            }
            if (!isLanded && !isJumped)
            {
                isJumped = true;
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            }
        }   
        
    }

    void toDest1()
    {
        rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
        if (transform.position.x >= dest1)
        {            
            StartCoroutine(DelayedPatrol());
        }

    }

    void toDest2()
    {
        rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        if (transform.position.x <= dest2)
        {
            StartCoroutine(DelayedPatrol());
        }
    }

    public void targeting()
    {
        isPatrol = false;
    }

    public float getSpeed()
    {
        return speed;
    }

    IEnumerator DelayedPatrol()
    {
        isWaiting = true;
        ani.SetBool("EnemyMoving", false);
        yield return new WaitForSecondsRealtime(2f);
        if (isReturn)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            isReturn = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            isReturn = true;
        }
        isWaiting = false;
        ani.SetBool("EnemyMoving", true);
    }

}
