using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private float dest1, dest2;
    private float speed = 100f;
    private Rigidbody2D rb2d;
    private bool isReturn = true;
    private Vector2 curVel;
    private bool isPatrol = true;
    private float jumpForce = 2500f;
    public bool isLanded = true;
    public bool isJumped = true;

    void Start()
    {
        dest1 = transform.position.x + 200;
        dest2 = transform.position.x - 200;
        rb2d = GetComponent<Rigidbody2D>();
        curVel = rb2d.velocity;
        curVel.x = speed;
    }

    void Update()
    {
        if(!isPatrol)
        {
            GetComponent<Patrol>().enabled = false;
        }
    }

    private void FixedUpdate()
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
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            isJumped = true;
        }
    }

    void toDest1()
    {
        rb2d.velocity = curVel;
        if (transform.position.x >= dest1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isReturn = true;
        }
    }

    void toDest2()
    {
        rb2d.velocity = -curVel;
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
