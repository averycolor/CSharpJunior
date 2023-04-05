using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : Bullet
{
    [SerializeField] private float _damageCoefficent;
    [SerializeField] private float _horizontalSpeedCoefficent;
    [SerializeField] private float _movementSpeed;

    private void Update()
    {
        transform.Translate(_movementSpeed * Vector3.left * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet) && bullet.UsedByEnemy)
        {
            if (bullet is ParabolicBullet parabolicBullet) {
                parabolicBullet.MultiplyHorizontalSpeed(_horizontalSpeedCoefficent);
            }

            bullet.MultiplyDamage(_damageCoefficent);
        }
    }
}
