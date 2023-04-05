using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected RandomizedValue _damage;

    public bool UsedByEnemy { get; protected set; } = false;

    public void UseByEnemy()
    {
        UsedByEnemy = true;
    }

    public void MultiplyDamage(float factor)
    {
        if (factor > 0)
        {
            _damage.Value *= factor;
        }
    }
}
