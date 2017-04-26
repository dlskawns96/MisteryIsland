using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarManager : MonoBehaviour {

    public GameObject cha;

    private int oriHp;

    private void Start()
    {
        oriHp = cha.GetComponent<CharacterStatus>().HP;
    }

    private void Update()
    {
        GetComponent<Image>().fillAmount = (float)cha.GetComponent<CharacterStatus>().HP / (float)oriHp;
    }

}
