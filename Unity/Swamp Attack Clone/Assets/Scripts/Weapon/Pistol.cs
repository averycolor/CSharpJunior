using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    private void Update()
    {
        UpdateFiringCooldown();
    }

    public override void StartShooting() {
        if (_currentFiringCooldown <= 0)
        {
            Instantiate(Bullet, ShootPoint.position + ShootOffset, ShootPoint.rotation);
            ResetFiringCooldown();
        }
    }
    public override void StopShooting() {}
    public override void Shoot() {}
}
