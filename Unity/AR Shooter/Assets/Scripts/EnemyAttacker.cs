using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : TimedAction
{
    [SerializeField] private int _damage;

    private Player _target;

    public void Init(Player target)
    {
        _target = target;
    }

    protected override void OnTimer()
    {
        _target.TakeDamage(_damage);
    }
}
