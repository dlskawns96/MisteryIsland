using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInMenu : MonoBehaviour {

    // Use this for initialization
    void Start() {
        StartCoroutine(Fade(50));
    }
    

    private IEnumerator Fade(float t)
    {
        while (transform.position.z < -30f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (Time.deltaTime * t));
            yield return null;
        }
    }
}
