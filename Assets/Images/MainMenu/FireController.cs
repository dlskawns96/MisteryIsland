using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {
    GameObject light;

    private void Start()
    {
        light = GameObject.Find("Candle");
    }

    private void Update()
    {
        if(light.transform.position.z >= -30)
        {
            GetComponent<Animator>().SetBool("fire", false);
        }
    }
}
