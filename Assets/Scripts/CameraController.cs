using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject character;
    private float offset;
    public bool isEndPoint = false;

    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("Character");
        offset = transform.position.x - character.transform.position.x;
    }

    private void LateUpdate()
    {
        if (!isEndPoint)
            transform.position = new Vector3(character.transform.position.x + offset, transform.position.y, -10);
     
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EndPoint")
            isEndPoint = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EndPoint")
            isEndPoint = false;
    }
}
