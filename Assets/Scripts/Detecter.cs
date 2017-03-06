using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecter : MonoBehaviour {

    private bool targeted = false;
    private float attackRange = 3f;
    private EnemyAttack monster;

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
                
            }
        }
    }
}
