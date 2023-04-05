using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstRifle : Weapon
{
    [SerializeField] private int _burstCount;
    [SerializeField] private float _burstDelay;

    private void Update()
    {
        UpdateFiringCooldown();
    }

    public override void Shoot() {}
    public override void StopShooting() {}

    public override void StartShooting()
    {
        if (_currentFiringCooldown <= 0)
        {
            StartCoroutine(Burst(ShootPoint));
            ResetFiringCooldown();
        }
    }

    private IEnumerator Burst(Transform point)
    {
        for (int i = 0; i < _burstCount; i++)
        {
            Instantiate(Bullet, ShootPoint.position + ShootOffset, ShootPoint.rotation);
            yield return new WaitForSeconds(_burstDelay);
        }
    }
}
