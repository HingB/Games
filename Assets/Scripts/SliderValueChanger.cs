using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SliderValueChanger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _duration;

    public void Change(float value)
    {
        float desiredValue = _slider.value + value;

        _slider.DOValue(desiredValue, _duration);
    }
}
