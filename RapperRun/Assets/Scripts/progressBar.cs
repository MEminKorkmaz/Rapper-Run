using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class progressBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxScore(int score){
        slider.maxValue = score;
        slider.value = score;
    }

    public void SetScore(int score){
        slider.value = score;
    }
}
