using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackState : AttackState
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _attackPoint;

    protected override void Attack()
    {
        Animator.SetTrigger("RangedAttack");

        Bullet newBullet = Instantiate(_bullet, _attackPoint.position, _attackPoint.rotation);
        newBullet.UseByEnemy();

        Attacked?.Invoke();
    }
}
