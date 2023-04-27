using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected int Health;

    public virtual event UnityAction<Entity> Died;

    public virtual void TakeDamage(int damage)
    {
        if (damage >= Health)
        {
            Health = 0;
            Die();
        }
        else
        {
            Health -= damage;
        }
    }

    protected virtual void Die()
    {
        Died?.Invoke(this);
    }
}
