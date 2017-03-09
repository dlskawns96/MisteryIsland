/*
 * 캐릭터의 각종 정보 및 스탯
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour {
    protected int HP = 30;

    public void attacked(int damage)
    {
        /*
         * 맞았으니까 잠시 무적 해주기
         */ 
         
        HP -= damage;
        Debug.Log(HP);
    }

    private void Update()
    {
        if(HP <= 0)
        {
            /*
             *   사망
             */
        }
    }
}
