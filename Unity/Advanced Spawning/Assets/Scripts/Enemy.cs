using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private EnemyTarget _target;
    private bool _isTargetAvailable;

    private void Update()
    {
        if (_isTargetAvailable)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        }
    }

    public void SetTarget(EnemyTarget target)
    {
        _target = target;
        _isTargetAvailable = _target != null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyTarget enemyTarget))
        {
            if (_target == enemyTarget)
            {
                Destroy(gameObject);
            }
        }
    }
}
