using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigation : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _path;

    private Transform[] _waypoints;
    private int _currentWaypointIndex;

    private void Start()
    {
        Waypoint[] waypoints = _path.GetComponentsInChildren<Waypoint>();
        _waypoints = new Transform[waypoints.Length];

        for (int i = 0; i < waypoints.Length; i++)
        {
            _waypoints[i] = waypoints[i].transform;
        }

        _currentWaypointIndex = 0;
    }

    private void Update()
    {
        Vector3 currentWaypointPosition = _waypoints[_currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, currentWaypointPosition, Time.deltaTime * _speed);

        if (transform.position == currentWaypointPosition)
        {
            _currentWaypointIndex += 1;

            if (_currentWaypointIndex >= _waypoints.Length)
            {
                _currentWaypointIndex = 0;
            }
        }
    }
}
