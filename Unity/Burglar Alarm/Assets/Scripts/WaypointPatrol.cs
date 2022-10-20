using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _movementSpeed;

    private int _currentPointIndex;
    private Transform _currentPoint;

    void Start()
    {
        _currentPointIndex = 0;
        NextPoint();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, _movementSpeed * Time.deltaTime);

        if (transform.position == _currentPoint.position)
        {
            NextPoint();
        }
    }

    void NextPoint()
    {
        _currentPointIndex += 1;

        if (_currentPointIndex >= _points.Length)
        {
            _currentPointIndex = 0;
        }

        _currentPoint = _points[_currentPointIndex];
        transform.LookAt(_currentPoint.position);
    }
}
