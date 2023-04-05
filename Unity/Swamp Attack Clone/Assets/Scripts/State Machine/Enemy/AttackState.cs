using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private RandomizedValue _attackInterval;
    [SerializeField] private RandomizedValue _damage;

    private float _timeToNextAttack;
    protected Animator Animator;

    [SerializeField] public UnityEvent Attacked;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Animator.SetBool("IsMoving", false);
        ResetAttackTimer();
    }

    private void ResetAttackTimer()
    {
        _timeToNextAttack = _attackInterval.Value;
    }

    private void Update()
    {
        _timeToNextAttack -= Time.deltaTime;

        if (_timeToNextAttack <= 0)
        {
            Attack();
            ResetAttackTimer();
        }
    }

    protected virtual void Attack()
    {
        Animator.SetTrigger("Attack");
        Target.TakeDamage(_damage.RoundedValue);
        Attacked?.Invoke();
    }
}