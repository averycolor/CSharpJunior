using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class SliderController : MonoBehaviour
{
    [SerializeField] private float _adjustmentSpeed;

    private Slider _slider;

    protected abstract float TargetValue { get; }

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, TargetValue, Time.deltaTime * _adjustmentSpeed);
    }
}
