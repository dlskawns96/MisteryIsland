using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour {

    public Light[] lights; //순서를 정해놓고 조건을 만족시키면 순서대로 불 켜주기
    private float[] oriIntensity;

    private void Start()
    {
        oriIntensity = new float[lights.Length];
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i])
            {
                oriIntensity[i] = lights[i].intensity;
                lights[i].intensity = 0;
            }
        }
    }

    public IEnumerator lightsOn()
    {
        for(int i = 0; i < lights.Length; i++)
        {
            if(lights[i])
            {
                StartCoroutine(lightOn(lights[i], i));
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }
    }
    
    private IEnumerator lightOn(Light light, int index)
    {
        while (light.intensity <= oriIntensity[index])
        {
            light.intensity += Time.deltaTime * 5;
            yield return null;
        }
        light.intensity = oriIntensity[index];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
            StartCoroutine(lightsOn());
    }

}
