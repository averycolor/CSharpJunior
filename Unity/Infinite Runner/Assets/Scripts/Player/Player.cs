using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _health;

    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health);
    }
    
    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            _health = 0;
        }

        HealthChanged?.Invoke(_health);
    }
}
