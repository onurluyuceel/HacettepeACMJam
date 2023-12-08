using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    // Start is called before the first frame update

    private Slider slider;
    public float sliderValue;
    private void Awake()
    {
        slider = GetComponent<Slider>(); 
    }

    public void Update()
    {
        SliderValueGet();
    }
    public void SliderValueGet()
    {
        sliderValue = slider.value;
    }
}
