using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineCheckManager : MonoBehaviour
{
    public Slider slider;
    public TimerManager timerManager;

    private int delLine = 0;

    public int DelLine
    {
        get => delLine;
        set => delLine = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 5;
        slider.value = delLine;
    }

    // Update is called once per frame
    void Update()
    {
        if (delLine == 5)
        {
            delLine = 0;
            timerManager.TimeCount += 3.0f;
        }

        slider.value = delLine;
    }
}
