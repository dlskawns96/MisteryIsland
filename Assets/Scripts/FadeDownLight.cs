using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeDownLight : MonoBehaviour {

    private Light light;

    private float start;
    public float end;
    private float t = 0.0f;
    private bool isDown = true;

    void Start()
    {
        light = GetComponent<Light>();
        start = light.intensity;
        
    }

    void Update()
    {

        if (light.intensity == start)
        {
            isDown = true;
            t = 0;
        }
        else if (light.intensity == end)
        {
            isDown = false;
            t = 0;
        }
        t += Time.deltaTime;

        if(isDown)
            light.intensity = Mathf.Lerp(start, end, t / 2);
        else
            light.intensity = Mathf.Lerp(end, start, t / 2);

    }
}
