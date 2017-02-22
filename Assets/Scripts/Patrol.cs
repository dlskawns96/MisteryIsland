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
        toDest1();
    }

    void Update()
    {
        if (isReturn)
            toDest2();
        else
            toDest1();
    }

    void toDest1()
    {
        Debug.Log("Heloo");
        
        rb2d.velocity = curVel;
        if(transform.position.x >= dest1)
            isReturn = true;
    }

    void toDest2()
    {
        Debug.Log("Heloo");
        rb2d.velocity = -curVel;
        if(transform.position.x <= dest2)        
            isReturn = false;
    }

    IEnumerator Return()
    {
        Debug.Log("Heloo");

        yield return new WaitForSeconds(1f);
                
        if (isReturn)
            toDest2();
        else
            toDest1();
         
    }
}
