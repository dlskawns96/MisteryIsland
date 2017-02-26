using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigJump : MonoBehaviour { 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "JumpPoint")
        {
            gameObject.GetComponentInParent<Patrol>().isLanded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            gameObject.GetComponentInParent<Patrol>().isLanded = true;
            gameObject.GetComponentInParent<Patrol>().isJumped = false;
        }
    }
}
