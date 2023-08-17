using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMover : TimedAction
{
    [SerializeField] private float _range;
    [SerializeField] private float _speed;

    private Coroutine _moveJob;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

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
            _rigidbody.MovePosition(Time.deltaTime * _speed * (destination - transform.position).normalized);
        }

        _moveJob = null;
    }
}
