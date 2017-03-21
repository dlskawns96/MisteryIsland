/*
 * 캐릭터의 각종 정보 및 스탯
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour {

    protected int HP = 30;
    private bool isUnbeatable;
    private Color col;
    private float t;

    private void Start()
    {
        col = GetComponent<SpriteRenderer>().color;
    }

    public void attacked(int damage)
    {
        /*
         * 맞았으니까 잠시 무적&넉백 해주기
         */     
        
        if(!isUnbeatable)
        {
            HP -= damage;
            Debug.Log(HP);
            isUnbeatable = true;
            StartCoroutine(makeBeatable());
        }
    }

    private void Update()
    {
        if(HP <= 0)
        {
            /*
             *   사망
             */
        }

        if(isUnbeatable)
        {
            
        }
    }

    IEnumerator makeBeatable()
    {
        /*
         * 반짝반짝 효과
         */
        StartCoroutine(makeTwinkle());
        Debug.Log("무적");
        yield return new WaitForSecondsRealtime(0.5f);
        isUnbeatable = false;
        col.a = 255;
    }

    IEnumerator makeTwinkle()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}
