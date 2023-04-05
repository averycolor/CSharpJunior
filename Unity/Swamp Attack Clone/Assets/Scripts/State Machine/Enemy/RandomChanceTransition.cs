using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChanceTransition : Transition
{
    [SerializeField] private float _checkInterval;
    [SerializeField, Range(0, 1)] private float _transitionChance;

    private Coroutine _checkTransitionChanceJob;

    private void Update()
    {
        if (_checkTransitionChanceJob == null)
        {
            _checkTransitionChanceJob = StartCoroutine(CheckTransitionChance());
        }
    }

    private IEnumerator CheckTransitionChance()
    {
        if (Random.Range(0f, 1f) <= _transitionChance)
        {
            NeedTransit = true;
        }

        yield return new WaitForSeconds(_checkInterval);

        _checkTransitionChanceJob = null;
    }
}
