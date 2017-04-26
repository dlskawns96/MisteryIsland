using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {

    public int hp;
    public bool isHitting;
    private float unbeatableTime = 0.5f;

    private void Update()
    {
        if(hp <= 0)
        {
            /*
             * 몬스터 죽음
             */
            this.gameObject.SetActive(false);
        }
    }

    public void isBeaten(int damage)
    {
        if(!isHitting)
        {
            hp -= damage;
            isHitting = true;
            StartCoroutine(makeBeatable());
        }        
    }

    IEnumerator makeBeatable()
    {
        GetComponent<Following>().isBeaten = true;
        GetComponent<Detecter>().isBeaten = true;
        yield return new WaitForSecondsRealtime(unbeatableTime);
        isHitting = false;
        GetComponent<Following>().isBeaten = false;
        GetComponent<Detecter>().isBeaten = false;
    }
}
