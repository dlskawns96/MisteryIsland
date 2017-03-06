using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    private GameObject target;
    
    public void targeting(GameObject target)
    {
        this.target = target;
    }

    public void attack()
    {
        //공격 모션 애니메이션 실행

    }
}
