using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject character;
    private float offset;

    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("Character");
        offset = transform.position.x - character.transform.position.x;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(character.transform.position.x + offset, transform.position.y, -10);
    }
}
