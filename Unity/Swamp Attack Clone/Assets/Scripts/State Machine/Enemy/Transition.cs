using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [field: SerializeField] public State TargetState { get; private set; }

    protected Player Target { get; private set; }

    public bool NeedTransit { get; protected set; }

    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }

    private void OnDisable()
    {   
    }
}
