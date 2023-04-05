using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveState : State
{
    [SerializeField] private float _speed;

    private void OnEnable()
    {
        GetComponent<Animator>().SetBool("IsMoving", true);
    }

    private void Update()
    {
        if (Target == null)
        {
            return;
        }

        transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, Target.transform.position.x, _speed * Time.deltaTime), transform.position.y);
    }
}
