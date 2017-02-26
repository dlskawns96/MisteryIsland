using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour {

    private bool targetOn = false, atLeft;
    private GameObject target;
    private float speed;
    private Rigidbody2D rb2d;

    private void Start()
    {
        speed = GetComponent<Patrol>().getSpeed();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(targetOn)
        {

            if (target.transform.position.x > transform.position.x) // 타겟이 오른쪽에 있으면
                atLeft = false;            
            else                                                    // 타겟이 왼쪽에 있으면
                atLeft = true;
        }
    }

    private void FixedUpdate()
    {
        if(targetOn)
        {
            if(atLeft)
            {

            }
            else
            {

            }
        }
    }

    public void targeting(GameObject target)
    {
        GetComponent<Patrol>().targeting();
        targetOn = true; 
        this.target = target;
    }
}
