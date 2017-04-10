using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecter : MonoBehaviour {

    public bool targeted = false;
    public bool isBeaten = false;
    private bool isAttacking = false;
    private bool canAttack = false;

    private float attackRange = 5f;
    private float attackDelay = 1f;
    private float attackTime = 0.2f;

    private int attackDamage = 10;

    private GameObject target;
    private BoxCollider2D collider2d;

    private bool isDetected;
    private float detectRange;
    private int mask;
    private RaycastHit2D hit2d;
    private RaycastHit2D attackHit2d;

    /*
     *  TriggerEnter로 들어오면 타이머를 키고
     *  TriggerExit으로 나갈때 타이머를 꺼서
     *  시간이 얼마나 경과했는지 검사
     *  딜레이보다 길게 지났으면 타격 성공
     */

    private void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();
        detectRange = collider2d.size.x * 2;
        mask = 1 << LayerMask.NameToLayer("Character");
    }

    private void FixedUpdate()
    {
        if (!targeted)
        {
            if (transform.rotation.y == -1)
            {
                hit2d = Physics2D.Raycast(transform.position, Vector2.right, detectRange, mask);
            }
            else
            {
                hit2d = Physics2D.Raycast(transform.position, Vector2.left, detectRange, mask);
            }
            if (hit2d)
            {
                GetComponent<Following>().targeting(hit2d.collider.gameObject);
                targeted = true;
                target = hit2d.collider.gameObject;
                detectRange = detectRange / 2;
            }
        }   
        else
        {
            if (transform.rotation.y == -1)
            {
                hit2d = Physics2D.Raycast(transform.position, Vector2.right, detectRange, mask);
            }
            else
            {
                hit2d = Physics2D.Raycast(transform.position, Vector2.left, detectRange, mask);
            }

            if(hit2d)
            {
                if (!isAttacking && !isBeaten)
                {
                    StartCoroutine(waitAndAttack());
                }
            }
        }
    }
    
    private void Update()
    {
        if(canAttack)
        {
            if (transform.rotation.y == -1)
            {
                attackHit2d = Physics2D.Raycast(transform.position, Vector2.right, detectRange, mask);
            }
            else
            {
                attackHit2d = Physics2D.Raycast(transform.position, Vector2.left, detectRange, mask);
            }

            if(attackHit2d)
            {
                if (!isBeaten)
                {
                    if (target.transform.position.x > transform.position.x)
                        target.GetComponent<CharacterStatus>().knockFromRight = false;
                    else
                        target.GetComponent<CharacterStatus>().knockFromRight = true;
                    target.GetComponent<CharacterStatus>().attacked(attackDamage);
                }
            }
        }
    }

    IEnumerator waitAndAttack()
    {
        isAttacking = true;
        GetComponent<Following>().isAttacking = true;
        yield return new WaitForSecondsRealtime(attackDelay);
        canAttack = true;
        yield return new WaitForSecondsRealtime(attackTime);
        isAttacking = false;
        canAttack = false;
        GetComponent<Following>().isAttacking = false;
    }
}
