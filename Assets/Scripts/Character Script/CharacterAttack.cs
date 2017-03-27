/*
 * 캐릭터 공격 스크립트
 * 컨트롤키를 눌러서 공격
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour {

    private int attackPower = 1;
    private float attackDelay = 0.2f;
    private bool isAttacking = false;
    private BoxCollider2D attackRange;
    
	void Start () {
        attackRange = GetComponent<BoxCollider2D>();
        attackRange.enabled = false;
	}

	void Update () {
        if(!isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                /*공격*/
                attackRange.enabled = true;
                isAttacking = true;
                StartCoroutine(attacking());
                StartCoroutine(delayAttack());
            }
        }
		
	}

    IEnumerator delayAttack()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        isAttacking = false;
    }

    IEnumerator attacking()
    {
        //공격애니메이션 실행

        yield return new WaitForSecondsRealtime(attackDelay);
        attackRange.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //공격
            collision.gameObject.GetComponent<EnemyStatus>().isBeaten(attackPower);
        }
    }
}
