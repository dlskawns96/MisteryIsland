﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed = 1f;


	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
