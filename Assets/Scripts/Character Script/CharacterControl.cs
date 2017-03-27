﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    public float speed = 100f;
    
    private Rigidbody2D rb2d;
    private Vector2 curVel;

    public bool isKnocked = false;

    void Start()
    {       
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        curVel = rb2d.velocity;        
    }

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.LeftArrow))
            transform.rotation = Quaternion.Euler(0, 180, 0);
       else if(Input.GetKeyDown(KeyCode.RightArrow))
            transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    void FixedUpdate()
    {
        if(!isKnocked)
        {
            curVel.x = Input.GetAxisRaw("Horizontal") * speed;
            rb2d.velocity = curVel;
        }
        else
        {
            StartCoroutine(waitKnocked());
            
        }
    }

    IEnumerator waitKnocked()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        isKnocked = false;
    }
}
