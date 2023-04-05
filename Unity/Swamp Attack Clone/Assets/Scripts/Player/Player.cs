using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int MaxHealth { get; private set; }

    public int Health { get; private set; }

    public int Money { get; private set; }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
    }

    public void OnEnemyDied(int reward)
    {
        Money += reward;
    }

    public bool AttemptPurchase(int price)
    {
        if (Money >= price)
        {
            Money -= price;
            return true;
        }

        return false;
    }

    private void Start()
    {
        Health = MaxHealth;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
