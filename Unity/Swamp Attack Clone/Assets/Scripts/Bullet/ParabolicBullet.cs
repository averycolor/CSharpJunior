using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicBullet : Bullet
{
    [SerializeField] private RandomizedValue _verticalSpeed;
    [SerializeField] private RandomizedValue _horizontalSpeed;

    private void Start()
    {
        _verticalSpeed.Freeze();
        _horizontalSpeed.Freeze();
    }

    private void Update()
    {
        transform.Translate(new Vector2(_horizontalSpeed.Value * Time.deltaTime * (UsedByEnemy? 1 : -1), _verticalSpeed.Value * Time.deltaTime), Space.World);
    }

    public void MultiplyHorizontalSpeed(float factor)
    {
        if (factor > 0)
        {
            _horizontalSpeed.Value *= factor;
        }
    }

    private void MakeContact(IDamageable target)
    {
        target.TakeDamage(_damage.RoundedValue);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (UsedByEnemy && collision.TryGetComponent(out Player player)) 
        {
            MakeContact(player);
        }
        else if (UsedByEnemy == false && collision.TryGetComponent(out Enemy enemy))
        {
            MakeContact(enemy);
        }

        if (collision.TryGetComponent(out Ground ground))
        {
            Destroy(gameObject);
        }
    }
}
