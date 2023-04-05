using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _entryState;

    private Enemy _enemy;

    public Player Target { get; private set; }
    public State CurrentState { get; private set; }

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        Target = _enemy.Target;
        Reset();
    }

    private void Update()
    {
        if (CurrentState == null)
        {
            return;
        }

        var nextState = CurrentState.GetNext();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    public void Reset()
    {
        CurrentState = _entryState;

        if (CurrentState == null == false)
        {
            CurrentState.Enter(Target);
        }
    }

    private void Transit(State destinationState)
    {
        if (CurrentState != null)
        {
            CurrentState.Exit();
        }

        CurrentState = destinationState;

        if (CurrentState != null) {
            CurrentState.Enter(Target);
        }
    }
}
