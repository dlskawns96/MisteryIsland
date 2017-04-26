/*
 * 캐릭터의 각종 정보 및 스탯
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour {

    public int HP = 30;
    private bool isUnbeatable;
    private Color col;
    private float t;
    private Rigidbody2D rb2d;

    private float knockback = 2;
    private float knockbackLength;
    private float knockbackCount = 0.2f;
    public bool knockFromRight;
    public bool isKnocked = false;

    private GameObject camera;

    private void Start()
    {
        col = GetComponent<SpriteRenderer>().color;
        rb2d = GetComponent<Rigidbody2D>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void attacked(int damage)
    {
        /*
         * 맞았으니까 잠시 무적&넉백 해주기
         */     
        
        if(!isUnbeatable)
        {
            HP -= damage;
            isUnbeatable = true;
            GetComponent<CharacterControl>().isKnocked = true;

            if (knockFromRight)
                rb2d.velocity = new Vector2(-knockback, knockback);
            else
                rb2d.velocity = new Vector2(knockback, knockback);

              
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
