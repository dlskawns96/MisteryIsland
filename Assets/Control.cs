using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    public int speed = 10;
    public float jumpForce = 20f;
    private bool grounded = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        GetComponent<Rigidbody2D>().velocity = new Vector2(xMove * speed, GetComponent<Rigidbody2D>().velocity.y);
	}

    void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            grounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }
}
