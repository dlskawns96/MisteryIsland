using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private float dest1, dest2;
    private float speed = 5f;
    private Rigidbody2D rb2d;
    private bool isReturn = false;
    private Vector2 curVel;
    private bool isPatrol = true;
    private bool isWaiting = false;

    void Start()
    {
        dest1 = transform.position.x + 3;
        dest2 = transform.position.x - 3;
        rb2d = GetComponent<Rigidbody2D>();
        curVel = rb2d.velocity;
        curVel.x = speed;
        toDest1();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Character")
        {
            isPatrol = false;
        }
    }

    void toDest1()
    {
        Debug.Log("Heloo");

        rb2d.velocity = curVel;
        if (transform.position.x >= dest1)
        {
            isWaiting = true;
            StartCoroutine(waitAndTurn());
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isReturn = true;
        }
    }

    void toDest2()
    {
        Debug.Log("Heloo");
        rb2d.velocity = -curVel;
        if (transform.position.x <= dest2)
        {
            isWaiting = true;
            StartCoroutine(waitAndTurn());
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isReturn = false;
        }
    }

    IEnumerator waitAndTurn()
    {
        yield return new WaitForSeconds(0.5f);
        isWaiting = false;
    }
}
