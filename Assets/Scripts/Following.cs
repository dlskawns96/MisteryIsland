using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour {

    GameObject target;
    private bool targetOn = false;
    private Rigidbody2D rb2d;
    private float speed;
    private float jumpForce = 100f;

	void Start () {
        target = null;
        rb2d = GetComponent<Rigidbody2D>();
        speed = GetComponent<Patrol>().getSpeed();
    }
	
	void Update () {
		if(targetOn)
        {
 
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Character")
        {
            target = collision.gameObject;
            targetOn = true;
        }
        if(collision.gameObject.tag == "JumpPoint")
        {
            Debug.Log("Jump!!!");
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }
}
