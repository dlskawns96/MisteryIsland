using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1CheckPoint : MonoBehaviour {

    public GameObject character;
    public GameObject stairs;

    private static bool isTouched = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Character")
        {
            //캐릭터한테 말풍선 + 느낌표
            character.GetComponent<SpriteRenderer>().flipX = true;
            stairs.SetActive(false);
            GameObject.Find("StairNFence").transform.position = new Vector3(GameObject.Find("StairNFence").transform.position.x, GameObject.Find("StairNFence").transform.position.y, -0.8f);
            isTouched = true;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (isTouched)
        {
            stairs.SetActive(false);
            GameObject.Find("StairNFence").transform.position = new Vector3(GameObject.Find("StairNFence").transform.position.x, GameObject.Find("StairNFence").transform.position.y, -0.8f);
            GameObject.Find("Character").transform.position = new Vector3(-6.34f, -3.91f, -1);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
