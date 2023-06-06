using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public TimeBar timeBar;
    
    public float timeRemaining;
    public float timeLimit = 60;

    void Start()
    {
        timeRemaining = timeLimit;
        timeBar.SetMaxTime(timeLimit);
    }

    void Update()
    {
        timeRemaining -= 1 * Time.deltaTime;
         timeBar.SetTime(timeRemaining);

    }
}
