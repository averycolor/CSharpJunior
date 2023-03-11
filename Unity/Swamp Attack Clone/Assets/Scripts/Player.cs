using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private int _startingWeaponIndex;
    [SerializeField] private Transform _shootPoint;

    [Header("Health")]
    [SerializeField] private int _maxHealth;

    private Weapon _currentWeapon;
    private int _health;
    private Animator _animator;

    public int Money { get; private set; }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
            Die();
        }
    }

    public void OnEnemyDied(int reward)
    {
        Money += reward;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _health = _maxHealth;

        if (_weapons.Count > _startingWeaponIndex)
        {
            _currentWeapon = _weapons[_startingWeaponIndex];
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }


    private void Die()
    {
        Destroy(gameObject);
    }
}
