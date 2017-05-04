using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {

    public int hp;
    public bool isHitting;
    private float unbeatableTime = 0.5f;
    private float afterDelay = 0.25f;

    private void Update()
    {
        if(hp <= 0)
        {
            StartCoroutine(EnemyDie());
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
        GetComponent<Animator>().SetBool("EnemyBeaten", true);
        yield return new WaitForSecondsRealtime(unbeatableTime);
        isHitting = false;
        GetComponent<Animator>().SetBool("EnemyBeaten", false);
        yield return new WaitForSecondsRealtime(afterDelay);        
        GetComponent<Detecter>().isBeaten = false;
        GetComponent<Following>().isBeaten = false;
    }

    IEnumerator EnemyDie()
    {
        GetComponent<Animator>().SetBool("EnemyDie", true);
        GetComponent<Detecter>().enabled = false;
        GetComponent<Following>().enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
        this.gameObject.SetActive(false);
    }
}
