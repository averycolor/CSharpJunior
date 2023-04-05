using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class HealthTransition : Transition
{
    [SerializeField] private RandomizedValue _threshold;

    private Enemy _enemy;

    private void Start()
    {
        _threshold.Freeze();
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (_enemy.Health < _threshold.Value)
        {
            NeedTransit = true;
        } 
    }
}
