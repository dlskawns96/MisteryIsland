using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabPatrol : MonoBehaviour {

    public float speed;
    private float dest1, dest2;
    
    private bool isReturn;
    private bool isHit;
    private bool wait = false;
    private bool runAway = false;

    private Rigidbody2D rb2d;
    private Animator ani;

    private float r, g, b, t = 1;

    void Start()
    {
        dest1 = transform.position.x + 4;
        dest2 = transform.position.x - 4;
        rb2d = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        isHit = false;
        StartCoroutine(Patrol());

        r = GetComponent<SpriteRenderer>().color.r;
        g = GetComponent<SpriteRenderer>().color.g;
        b = GetComponent<SpriteRenderer>().color.b;
    }

    private void Update()
    {
        if(runAway)
        {
            if (transform.position.x > GameObject.Find("Character").transform.position.x) //게가 오른쪽
            {
                if (transform.position.x - GameObject.Find("Character").transform.position.x > 10)
                {
                    runAway = false;
                    gameObject.SetActive(false);
                }
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            }
            else
            {
                if (GameObject.Find("Character").transform.position.x - transform.position.x> 10)
                {
                    runAway = false;
                    gameObject.SetActive(false);
                }
                rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            }            
        }
    }

    void toDest1()
    {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        if (transform.position.x >= dest1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            isReturn = true;
            wait = true;
        }
    }

    void toDest2()
    {
        rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        if (transform.position.x <= dest2)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            isReturn = false;
            wait = true;
        }
    }

    IEnumerator Patrol()
    {        
        ani.SetBool("CrabMoving", true);
        if (isReturn)
            toDest2();
        else
            toDest1();
        if (wait)
        {
            ani.SetBool("CrabMoving", false);
            yield return new WaitForSecondsRealtime(2f);
            wait = false;
        }
        else
            yield return null;

        if (!isHit)
            StartCoroutine(Patrol());             
    }

    IEnumerator RunAway()
    {
        yield return new WaitForSecondsRealtime(1f);
        ani.SetBool("CrabHit", false);
        ani.SetBool("CrabMoving", true);
        speed = 6f;
        runAway = true;
    }

    public void beaten()
    {
        isHit = true;
        ani.SetBool("CrabHit", true);
        StartCoroutine(RunAway());
    }
}
