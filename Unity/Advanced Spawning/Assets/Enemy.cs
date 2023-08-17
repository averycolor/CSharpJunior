using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private EnemyTarget _target;

    private void Update()
    {
        if (_target != null)
        {
            if (transform.position == _target.transform.position)
            {
                Destroy(gameObject);
            } 
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
            }
        }
    }

    public void SetTarget(EnemyTarget target)
    {
        _target = target;
    }
}
