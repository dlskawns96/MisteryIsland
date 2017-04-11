using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public void startButton()
    {
        StartCoroutine(changeScene());       
    }

    private IEnumerator changeScene()
    {
        GameObject.Find("ButtonManager").GetComponent<AudioSource>().Play();
        yield return new WaitForSecondsRealtime(0.3f);
        SceneManager.LoadScene(1);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
}
