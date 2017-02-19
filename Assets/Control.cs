using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    public float speed = 5f;
    
    private Rigidbody2D rb2d;
    private Vector2 curVel;
    private float jumpPower = 150f;
    private bool grounded = true;
    
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        curVel = rb2d.velocity;
    }


    void Update()
    {
        
    }

    void FixedUpdate()
    {
        curVel.x = Input.GetAxis("Horizontal") * speed;
        rb2d.velocity = curVel;

        if (grounded && Input.GetKeyUp(KeyCode.Space))
        {
            grounded = false;
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
