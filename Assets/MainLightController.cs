using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLightController : MonoBehaviour {

    public GameObject cha;

	void Update () {
        transform.position = new Vector3(cha.transform.position.x - 1.5f, 4f, -4f);
    }
}
