using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecter : MonoBehaviour {

    public bool targeted = false;
    public bool isBeaten = false;
    private bool isAttacking = false;

    private float attackRange = 5f;
    private float attackDelay = 1f;
    private float attackTime = 0.2f;

    private int attackDamage = 10;

    private GameObject target;
    private BoxCollider2D collider2d;
    

    /*
     *  TriggerEnter로 들어오면 타이머를 키고
     *  TriggerExit으로 나갈때 타이머를 꺼서
     *  시간이 얼마나 경과했는지 검사
     *  딜레이보다 길게 지났으면 타격 성공
     */

    private void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            target = collision.gameObject;
            if (!targeted)
            {
                GetComponentInParent<Following>().targeting(collision.gameObject);               
                collider2d.size = new Vector2(attackRange, collider2d.size.y);

                targeted = true;
            }
            else
            {
                if(!isAttacking && !isBeaten)
                {
                    StartCoroutine(waitAndAttack());
                }
                else if(!isBeaten)
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
        GetComponentInParent<Following>().isAttacking = true;
        collider2d.size = new Vector2(0, 0);
        yield return new WaitForSecondsRealtime(attackDelay);
        collider2d.size = new Vector2(attackRange, 1.95f);
        yield return new WaitForSecondsRealtime(attackTime);
        isAttacking = false;
        GetComponentInParent<Following>().isAttacking = false;
    }
}
