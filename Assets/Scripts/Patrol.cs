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

    void Start()
    {
        dest1 = transform.position.x + 3;
        dest2 = transform.position.x - 3;
        rb2d = GetComponent<Rigidbody2D>();
        curVel = rb2d.velocity;
        curVel.x = speed;
        StartCoroutine("pause");
    }

    void Update()
    {
        
    }

    void toDest1()
    {
        while(transform.position.x <= dest1)
        {
            rb2d.velocity = curVel;
        }
        isReturn = true;
        StartCoroutine(pause());
    }

    void toDest2()
    {
        while (transform.position.x >= dest2)
        {
            rb2d.velocity = -curVel;            
        }
        isReturn = false;
        StartCoroutine(pause());
    }

    IEnumerator pause()
    {
        Debug.Log("Heloo");
        yield return new WaitForSeconds(0.5f);
        if (isReturn)
            toDest2();
        else
            toDest1();
    }
}
