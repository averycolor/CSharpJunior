using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigation : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;
    private int _currentWaypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        _currentWaypointIndex = 0;
    }

    // Update is called once per frame
    void Update()
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
