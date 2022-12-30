using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _stepSize;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _maximumHeight;
    [SerializeField] private float _minimumHeight;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        MoveToTarget();
    }

    public void StepUp()
    {
        Step(_stepSize);
    }

    public void StepDown()
    {
        Step(-_stepSize);
    }

    private void Step(float stepSize)
    {
        _targetPosition = new Vector2(transform.position.x, _targetPosition.y + stepSize);

        if (_targetPosition.y > _maximumHeight)
        {
            _targetPosition.y = _maximumHeight;
        }
        else if (_targetPosition.y < _minimumHeight)
        {
            _targetPosition.y = _minimumHeight;
        }
    }

    private void MoveToTarget()
    {
        if (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);
        }
    }
}
