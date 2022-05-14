using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text timerText;

    float timeCount = 60.0f;

    public float TimeCount
    {
        get => timeCount;
        set => timeCount = value;
    }

    private void Start()
    {
        timerText.text = timeCount.ToString();
    }

    private void Update()
    {
        timeCount -= Time.deltaTime;

        if (timeCount <= 0)
        {
            timeCount = 0;
        }

        timerText.text = timeCount.ToString("F0");
    }

}
