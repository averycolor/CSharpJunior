using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private int _value;
    
    [SerializeField] private int _maxValue;

    public int MaxValue => _maxValue;

    public event UnityAction<int> Changed;

    private void Start()
    {
        _value = _maxValue;
        Changed?.Invoke(_value);
    }

    public void TakeDamage(int damage)
    {
        _value = Mathf.Max(0, _value - damage);
        Changed?.Invoke(_value);

        if (_value == 0)
        {
            Die();
        }
    }

    public void TakeHealing(int healing)
    {
        _value = Mathf.Min(_maxValue, _value + healing);
        Changed?.Invoke(_value);
    }


    private void Die()
    {
        Application.Quit();
    }
}
