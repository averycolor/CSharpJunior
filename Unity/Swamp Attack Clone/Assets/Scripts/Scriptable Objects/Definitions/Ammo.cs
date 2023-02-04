using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammo : ScriptableObject
{
    [SerializeField] protected float Speed;
    [SerializeField] protected int Damage;
    [SerializeField] protected GameObject Prefab;

    public abstract void Hit(GameObject target);

    public GameObject Make()
    {
        return Instantiate(Prefab);
    }
}
