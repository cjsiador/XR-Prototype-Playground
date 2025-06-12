using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public float FillSpeed = 0.5f;
    public float targetProgress = 0;
    // public ContentIndex contextScript;

    void Update()
    {
        // slider.maxValue = contextScript.indexContentMax;
        // targetProgress = contextScript.indexContent;
        CheckIncrement();
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }

    public void CheckIncrement()
    {
        if(slider.value == targetProgress)
            slider.value = targetProgress;

        if(slider.value < targetProgress)
            slider.value += FillSpeed * Time.deltaTime;

        if(slider.value > targetProgress)
            slider.value -= FillSpeed * Time.deltaTime;
    }
}
