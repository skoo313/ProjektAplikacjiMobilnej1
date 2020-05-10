﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void ResetHP(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;

        
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHP(int hp)
    {
        slider.value = hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
