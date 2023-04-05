using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private RandomizedValue _threshold;

    void Start()
    {
        _threshold.Freeze();
    }

    private void Update()
    {
        if (Target == null)
        {
            return;
        }

        if (Vector2.Distance(transform.position, Target.transform.position) < _threshold.Value)
        {
            NeedTransit = true;
        }
    }
}
