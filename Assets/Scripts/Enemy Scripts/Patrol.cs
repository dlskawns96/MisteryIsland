using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private float dest1, dest2;
    private float speed = 5f;
    private Rigidbody2D rb2d;
    private bool isReturn = true;
    private Vector2 curVel;
    private bool isPatrol = true;
    private float jumpForce = 20f;
    public bool isLanded = true;
    public bool isJumped = false;
    private bool isBeating = false;
    
    void Start()
    {
        dest1 = transform.position.x + 10;
        dest2 = transform.position.x - 10;
        rb2d = GetComponent<Rigidbody2D>();
        curVel = rb2d.velocity;
        curVel.x = speed;
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
                if (isReturn)
                    toDest2();
                else
                    toDest1();
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
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isReturn = true;
        }

    }

    void toDest2()
    {
        rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        if (transform.position.x <= dest2)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isReturn = false;
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


}
