using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject[] uis;
    private Color tmp;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < uis.Length; i++)
        {
            uis[i].GetComponent<FadeDown>().fade();
        }
	}	
}
