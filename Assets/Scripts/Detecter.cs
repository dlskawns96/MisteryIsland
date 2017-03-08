using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecter : MonoBehaviour {

    private bool targeted = false;
    private float attackRange = 3f;
    private float attackDelay = 0.5f;
    private int attackDamage = 10;
    private float takenTime;
    private EnemyAttack monster;
    private bool isIn;

    /*
     * TriggerEnter로 들어오면 타이머를 키고
     * TriggerExit으로 나갈때 타이머를 꺼서
     * 시간이 얼마나 경과했는지 검사
     *  딜레이보다 길게 지났으면 타격 성공
     */

    private void Start()
    {
        monster = GetComponentInParent<EnemyAttack>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            if (!targeted)
            {
                GetComponentInParent<Following>().targeting(collision.gameObject);               
                GetComponent<BoxCollider2D>().size = new Vector2(attackRange, GetComponent<BoxCollider2D>().size.y);

                monster.targeting(collision.gameObject);
                monster.enabled = true;
                targeted = true;
            }
            else
            {
                GetComponentInParent<Following>().isAttacking= true;
                isIn = true;
                takenTime = 0f;                
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Character")
        {
            if(targeted)
            {
                /*
                 * 공격 애니메이션 실행
                 */             

                if(takenTime < attackDelay)
                    takenTime += Time.deltaTime;
                else
                {
                    /*
                     * 딜레이 만큼 시간이 지났는데 아직도 공격범위에 있다면 공격 
                     */
                    if(isIn)                  
                        collision.gameObject.GetComponent<CharacterStatus>().attacked(attackDamage);

                    takenTime = 0;
                    GetComponentInParent<Following>().isAttacking = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Character")
        {
            isIn = false;
        }
    }
}
