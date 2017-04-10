using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour {

   void Start() {
        StartCoroutine(Fade(100));
    }
    

    private IEnumerator Fade(float t)
    {
        while (GetComponent<Image>().fillAmount <= 1)
        {
            GetComponent<Image>().fillAmount += Time.deltaTime * t / 100;
            yield return null;
        }
    }
}
