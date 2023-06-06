using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    public float timeRemaining;
    [SerializeField] float timeLimit = 60;
    public void SetMaxTime(float time)
    {
        slider.maxValue = time;
        slider.value = time;
    }

    public void SetTime(float time){
        slider.value = time;
    }

    public float getTime()
    {
        return timeRemaining;
    }

    public float getDuration()
    {
        return timeLimit;
    }
    void Start()
    {
        timeRemaining = timeLimit;
        SetMaxTime(timeLimit);
    }

    void Update()
    {  
        timeRemaining -= 1 * Time.deltaTime;
        SetTime(timeRemaining);
        if(timeRemaining <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }

    
}
