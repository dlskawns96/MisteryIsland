using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 캐릭터의 각종 정보 및 스탯
 */

public class CharacterStatus : MonoBehaviour {
    protected int HP = 30;

    public void attacked(int damage)
    {
        HP -= damage;
        Debug.Log(HP);
    }

    private void Update()
    {
        if(HP <= 0)
        {
            /*
             * 사망
             */
        }
    }
}
