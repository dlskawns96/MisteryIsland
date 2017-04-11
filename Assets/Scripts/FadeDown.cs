using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeDown : MonoBehaviour {
    
    public void fade()
    {
        if(GetComponent<Text>())
        {
            StartCoroutine(FadeTextToZeroAlpha(5, GetComponent<Text>()));
        }
        else
        {
            StartCoroutine(FadeImageToZeroAlpha(5, GetComponent<Image>()));
        }
    }
    

    private IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    private IEnumerator FadeImageToZeroAlpha(float t, Image i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
