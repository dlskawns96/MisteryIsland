using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    public float speed = 5f;
    
    private Rigidbody2D rb2d;
    private Vector2 curVel;

    

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        curVel = rb2d.velocity;
        
    }
    
    void FixedUpdate()
    {
        curVel.x = Input.GetAxis("Horizontal") * speed;
        rb2d.velocity = curVel;

        
    }
    
}
