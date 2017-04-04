using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    public float speed;
    public static BackgroundScroller current;
    public Material mat;


    float pos = 0;

	// Use this for initialization
	void Start () {
        current = this;
	}
	
	// Update is called once per frame
	void Update () {
        pos += speed;
        if (pos > 1.0f)
            pos -= 1.0f;

        mat.mainTextureOffset = new Vector2(pos, 0);
	}
}
