using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private PathNode _startingNode;
    [SerializeField] private float _movementSpeed;

    private PathNode _targetNode;
    private Coroutine _moveJob;

    private void Start()
    {
        _targetNode = _startingNode;
    }

    private void Update()
    {
        if (_targetNode != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetNode.transform.position, _movementSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PathNode collidedNode))
        {
            if (_targetNode == collidedNode)
            {
                _targetNode = _targetNode.GetNext();
            }
        }
    }
}
