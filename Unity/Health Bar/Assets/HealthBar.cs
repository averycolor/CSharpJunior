using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider _slider;
    private float _healthTarget;

    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _adjustmentSpeed;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _playerHealth.MaxValue;
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _healthTarget, _adjustmentSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _playerHealth.Changed += OnHealthChanged;
    }

    private void OnDisable()
    {
        _playerHealth.Changed -= OnHealthChanged;
    }

    public void OnHealthChanged(int health)
    {
        _healthTarget = health;
    }
}
