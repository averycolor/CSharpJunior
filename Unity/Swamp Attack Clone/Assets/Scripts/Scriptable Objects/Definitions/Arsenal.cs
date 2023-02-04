using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ArsenalWeapon
{
    private Weapon _weapon;
    private int _ammoStored;
    private int _ammoLoaded;

    public void Reload()
    {
        _ammoLoaded = Mathf.Min(_weapon.MagazineCapacity, _ammoStored);
        _ammoStored -= _ammoLoaded - _weapon.MagazineCapacity;
    }

    public void StartShooting(Transform originPoint)
    {
        _weapon.StartShooting(originPoint);
    }

    public void Shoot(Transform originPoint)
    {
        _weapon.Shoot(originPoint);
    }

    public void StopShooting(Transform originPoint)
    {
        _weapon.StopShooting(originPoint);
    }
}

public class Arsenal : ScriptableObject
{
    private List<ArsenalWeapon> _arsenalWeapons;

    public bool TryAddWeapon(Weapon weapon)
    {
        return true;
    }
}
