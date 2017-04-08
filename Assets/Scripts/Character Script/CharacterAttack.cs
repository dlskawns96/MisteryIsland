﻿/*
 * 캐릭터 공격 스크립트
 * 컨트롤키를 눌러서 공격
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour {

    private int attackPower = 1;
    private float attackDelay = 0.5f;
    private float attackTime = 0.2f;

    private bool isAttacking = false;
    private BoxCollider2D attackRange;

    private RaycastHit2D hit2d;
    private float rayRange;

    private bool canAttack;
    private int mask;

    private SpriteRenderer renderer;

	void Start () {
        attackRange = GetComponent<BoxCollider2D>();
        attackRange.enabled = false;
        rayRange = attackRange.size.x / 2;
        mask = 1 << LayerMask.NameToLayer("Enemy");
        renderer = GetComponentInParent<SpriteRenderer>();
       
    }

	void Update () {
        if (!isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                /*공격*/
                StartCoroutine(attacking());
            }
        }
        else
        {
            if (renderer.flipX) //왼쪽
            {
                hit2d = Physics2D.Raycast(transform.position, Vector2.left, rayRange, mask);
                Debug.DrawRay(transform.position, Vector2.left);
            }
            else
                hit2d = Physics2D.Raycast(transform.position, Vector2.right, rayRange, mask);

            if(hit2d)
            {
                hit2d.collider.gameObject.GetComponent<EnemyStatus>().isBeaten(attackPower);
            }
        }
		
	}

    IEnumerator delayAttack()
    {
        isAttacking = true;
        yield return new WaitForSecondsRealtime(attackTime);
        isAttacking = false;
    }

    IEnumerator attacking()
    {
        //공격애니메이션 실행        
        yield return new WaitForSecondsRealtime(attackDelay);
        StartCoroutine(delayAttack());
    }
}
