using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	public void startButton()
    {
        SceneManager.LoadScene(1);
    }

    private void OnMouseOver()
    {

    }
}
