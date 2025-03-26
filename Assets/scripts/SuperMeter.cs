using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperMeter : MonoBehaviour
{
    [SerializeField] Slider slider;


    public void UpdateBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    //Move this to player Script.
    [SerializeField] float meter, maxMeter = 10f;
    [SerializeField] SuperMeter meterBar;

    private void Start()
    {
        meter = 0f;
        meterBar.UpdateBar(meter, maxMeter); //and this to the code where the meter increases as wellS
    }
}
