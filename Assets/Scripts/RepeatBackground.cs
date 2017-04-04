using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour {

    private BoxCollider2D boxCollider;
    private float groundHorizontalLength;

	// Use this for initialization
	void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = boxCollider.size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -groundHorizontalLength)
            repositioningBackgrounds();
	}

    private void repositioningBackgrounds()
    {
        Vector3 groundOffset = new Vector3(groundHorizontalLength * 2f, 0, 5.5f);
        transform.position = new Vector3(transform.position.x + groundOffset.x, 0, 5.5f);
          
    }
}
