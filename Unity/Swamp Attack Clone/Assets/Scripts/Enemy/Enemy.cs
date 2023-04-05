using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private RandomizedValue _health;
    [SerializeField] private RandomizedValue _reward;
    [field: SerializeField] public Vector3 SpawnOffset { get; private set; }

    private Animator _animator;

    public Player Target { get; private set; }
    public int Health => _health.RoundedValue;

    public event UnityAction<int> Dying;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _health.Freeze();
        _reward.Freeze();
    }

    public void TakeDamage(int damage)
    {
        _health.Value -= damage;
        _animator.SetTrigger("Hit");

        if (_health.Value <= 0)
        {
            Dying?.Invoke(_reward.RoundedValue);
        }
    }

    public void Init(Player target)
    {
        Target = target;
        OnEnable();
    }

    private void OnDeath(int reward)
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        if (Target != null)
        {
            Dying += Target.OnEnemyDied;
        }

        Dying += OnDeath;
    }

    private void OnDisable()
    {
        if (Target != null)
        {
            Dying -= Target.OnEnemyDied;
        }

        Dying -= OnDeath;
    }
}
