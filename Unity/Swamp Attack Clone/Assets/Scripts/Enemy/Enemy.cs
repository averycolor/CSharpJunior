using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    public Player Target { get; private set; }

    public event UnityAction<int> Dying;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke(_reward);
        }
    }

    private void OnDeath(int reward)
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        Dying += Target.OnEnemyDied;
        Dying += OnDeath;
    }

    private void OnDisable()
    {
        Dying -= Target.OnEnemyDied;
        Dying -= OnDeath;
    }
}
