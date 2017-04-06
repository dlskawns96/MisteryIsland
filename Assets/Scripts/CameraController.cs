using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private float rayDistance;
    private bool hitLeft, hitRight;
    private int mask;

    private void Start()
    {
        mask = 1 << LayerMask.NameToLayer("EndPoint");
        rayDistance = (GetComponent<BoxCollider2D>().size.x * 2) + 0.1f;
    }

    private void Update()
    {
        Ray2D leftRay = new Ray2D(transform.position, Vector2.left);
        Ray2D rightRay = new Ray2D(transform.position, Vector2.right);

        hitLeft = Physics2D.Raycast(leftRay.origin, leftRay.direction, rayDistance, mask);
        hitRight = Physics2D.Raycast(rightRay.origin, rightRay.direction, rayDistance, mask);
    }

    private void LateUpdate()
    {       
        move();
    }
    
    void move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0 && !hitLeft)
        {
            moveVelocity = Vector3.left;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0 && !hitRight)
        {
            moveVelocity = Vector3.right;
        }

        transform.position += moveVelocity * 2f * Time.deltaTime;
    }

}
