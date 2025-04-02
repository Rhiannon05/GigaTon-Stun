using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] Slider slider;


    public void UpdateBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }


    void Start()
    {

    }


    void Update()
    {
    }
}
