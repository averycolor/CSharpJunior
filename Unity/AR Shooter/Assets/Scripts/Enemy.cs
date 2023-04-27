using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyAttacker))]
public class Enemy : Entity
{
    [field: SerializeField] public int Reward { get; private set; }

    private Player _target;
    private EnemyAttacker _attacker;

    public void Init(Player target)
    {
        _attacker = GetComponent<EnemyAttacker>();

        _target = target;

        _attacker.Init(_target);
    }

    private void OnEnable()
    {
        Died += OnDeath; 
    }

    private void OnDisable()
    {
        Died -= OnDeath;
    }

    private void OnDeath(Entity self)
    {
        Destroy(gameObject);
    }
}