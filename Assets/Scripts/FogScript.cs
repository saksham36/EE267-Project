using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogScript : MonoBehaviour
{
    [SerializeField] float minFogDensity = 0.05f;
    [SerializeField] float maxFogDensity = 0.4f;
    [SerializeField] float duration;
    [SerializeField] float timeOffset;
    [SerializeField] Color startFogColor;
    [SerializeField] Color endFogColor;

    Color fogColor;
    float fogDensity;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fog = true;
        fogDensity = minFogDensity;
        fogColor = startFogColor;
        RenderSettings.fogDensity = fogDensity;
        RenderSettings.fogColor = fogColor;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if(time > timeOffset)
        {
            fogColor.r = startFogColor.r + (endFogColor.r-startFogColor.r) * (time-timeOffset)/(duration-timeOffset);
            fogColor.g = startFogColor.g + (endFogColor.g-startFogColor.g) * (time-timeOffset)/(duration-timeOffset);
            fogColor.b = startFogColor.b + (endFogColor.b-startFogColor.b) * (time-timeOffset)/(duration-timeOffset);
            fogColor.a = startFogColor.a + (endFogColor.a-startFogColor.a) * (time-timeOffset)/(duration-timeOffset);
            RenderSettings.fogColor = fogColor;
                
            RenderSettings.fogDensity = minFogDensity + (maxFogDensity-minFogDensity) * (time-timeOffset)/(duration-timeOffset);
        }
        if(time < duration)
        {
            time += Time.deltaTime;
        }
    }
}
