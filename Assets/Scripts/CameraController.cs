using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Vector2 curVel;
    public bool isBeaten = false;

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        curVel = rb2d.velocity;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(!isBeaten)
        {
            curVel.x = Input.GetAxisRaw("Horizontal") * 100f;
            rb2d.velocity = curVel;
        }        
    }
}
