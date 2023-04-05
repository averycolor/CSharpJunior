using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredTransition : Transition
{
    public void Trigger()
    {
        NeedTransit = true;
    }
}
