using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject cha;

    private void Update()
    {
        this.transform.position = new Vector3(4.6f + cha.transform.position.x, 0f, -10f);
    }
}
