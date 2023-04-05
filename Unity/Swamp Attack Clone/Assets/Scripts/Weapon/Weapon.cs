using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected Vector3 ShootOffset;

    protected Transform ShootPoint;
    protected float _currentFiringCooldown;

    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField, TextArea] public string Description { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public bool IsBought { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public RandomizedValue FiringCooldown { get; private set; }

    public virtual void Init(Transform shootPoint)
    {
        ShootPoint = shootPoint;
    }

    public abstract void StartShooting();
    public abstract void Shoot();
    public abstract void StopShooting();

    public void Buy()
    {
        IsBought = true;
    }

    protected void ResetFiringCooldown()
    {
        _currentFiringCooldown = FiringCooldown.Value;
    }

    protected void UpdateFiringCooldown()
    {
        if (_currentFiringCooldown > 0)
        {
            _currentFiringCooldown -= Time.deltaTime;
        }
    }
}
