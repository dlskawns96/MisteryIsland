using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecter : MonoBehaviour {

    public bool targeted = false;
    private float attackRange = 3f;
    private float attackDelay = 1f;
    private int attackDamage = 10;
    public float takenTime;
    private bool isIn;
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

    private void Update()
    {

        if (takenTime >= attackDelay)
        {
            Debug.Log("업데이트에 걸림");
            target.gameObject.GetComponent<CharacterStatus>().attacked(attackDamage);
            takenTime = 0;
        }   
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
                GetComponentInParent<Following>().isAttacking= true;
                //takenTime = 0f;
                //StartCoroutine(counter());
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
                 *   공격 애니메이션 실행
                 */
                
                GetComponentInParent<Following>().isAttacking = true;
                takenTime += Time.deltaTime;
                Debug.Log("스때이");
                
                    /*
                     *   딜레이 만큼 시간이 지났는데 아직도 공격범위에 있다면 공격 
                   
                    takenTime = 0;
                    GetComponentInParent<Following>().isAttacking = false;  */
                    
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Character")
        {
            if(takenTime >= attackDelay)
            {
                takenTime = 0;
                GetComponentInParent<Following>().isAttacking = false;
            }
            else
            {
                Debug.Log("나가자자ㅏ");
                StartCoroutine(waitAndContinue(attackDelay - takenTime));
            }
        }
    }

    IEnumerator counter()
    {
        yield return new WaitForSecondsRealtime(attackDelay);
        Debug.Log("코루틴 : " + takenTime);
        if (takenTime >= attackDelay)
        {
            target.gameObject.GetComponent<CharacterStatus>().attacked(attackDamage);
            Debug.Log("코루틴에 걸림");
        }
        GetComponentInParent<Following>().isAttacking = false;
    }

    IEnumerator waitAndContinue(float leftTime)
    {
        yield return new WaitForSecondsRealtime(leftTime);
        takenTime = 0;
        GetComponentInParent<Following>().isAttacking = false;
    }
}
