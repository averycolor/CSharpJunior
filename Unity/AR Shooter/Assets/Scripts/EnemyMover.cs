using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : TimedAction
{
    [SerializeField] private float _range;
    [SerializeField] private float _speed;

    private Coroutine _moveJob;

    protected override void OnTimer()
    {
        if (_moveJob == null)
        {
            _moveJob = StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        Vector3 destination = Random.insideUnitSphere * _range;
        destination.y = Mathf.Abs(destination.y);

        while (transform.position != destination)
        {
            yield return null;
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * _speed);
        }

        _moveJob = null;
    }
}
