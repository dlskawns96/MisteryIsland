using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingLight : MonoBehaviour {

    private GameObject cha;

	// Use this for initialization
	void Start () {
        cha = GameObject.Find("Character");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(cha.transform.position.x, cha.transform.position.y, -2.25f);
	}
}
