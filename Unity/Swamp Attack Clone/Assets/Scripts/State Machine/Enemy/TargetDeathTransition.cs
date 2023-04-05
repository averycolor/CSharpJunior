using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDeathTransition : Transition
{
    void Update()
    {
        if (Target == null)
        {
            NeedTransit = true;
        }
    }
}
