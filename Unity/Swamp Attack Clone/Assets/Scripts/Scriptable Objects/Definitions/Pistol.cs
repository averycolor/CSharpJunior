using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pistol", menuName = "Weapon System/Pistol")]
public class Pistol : Weapon
{
    public override void StartShooting(Transform muzzleTransform)
    {
        GameObject bullet = Ammo.Make();
        bullet.transform.position = muzzleTransform.position;
        bullet.transform.rotation = muzzleTransform.rotation;
    }

    public override void Shoot(Transform source)
    {

    }

    public override void StopShooting(Transform source)
    {

    }
}
