using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private void Start()
    {
        GetComponent<Animator>().SetBool("IsMoving", false);
    }
}
