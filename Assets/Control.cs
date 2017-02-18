using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    public int speed = 10;
    public float jumpForce = 100f;
    private bool grounded = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        GetComponent<Rigidbody2D>().velocity = new Vector2(xMove * speed, GetComponent<Rigidbody2D>().velocity.y);
	}

    void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            grounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

        //출동체크해서 땅에 닿으면 grounded를 true로 해주기
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
