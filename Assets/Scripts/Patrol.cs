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
    private bool isWaiting = false;

    void Start()
    {
        dest1 = transform.position.x + 100;
        dest2 = transform.position.x - 100;
        rb2d = GetComponent<Rigidbody2D>();
        curVel = rb2d.velocity;
        curVel.x = speed;
    }

    void Update()
    {
        if(isPatrol && !isWaiting)
        {
            if (isReturn)
                toDest2();
            else
                toDest1();
        }
    }

    void toDest1()
    {
        rb2d.velocity = curVel;
        if (transform.position.x >= dest1)
        {
            isWaiting = true;
            StartCoroutine(waitAndTurn());
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isReturn = true;
        }
    }

    void toDest2()
    {
        rb2d.velocity = -curVel;
        if (transform.position.x <= dest2)
        {
            isWaiting = true;
            StartCoroutine(waitAndTurn());
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isReturn = false;
        }
    }

    IEnumerator waitAndTurn()
    {
        yield return new WaitForSeconds(0.5f);
        isWaiting = false;
    }

    public float getSpeed()
    {
        return speed;
    }
}
