using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    [SerializeField] public int Price { get; protected set; }
    [SerializeField] public int MagazineCapacity { get; protected set; }
    [SerializeField] public Ammo Ammo { get; protected set; }

    public abstract void StartShooting(Transform bulletOrigin);
    public abstract void Shoot(Transform bulletOrigin);
    public abstract void StopShooting(Transform bulletOrigin);
}