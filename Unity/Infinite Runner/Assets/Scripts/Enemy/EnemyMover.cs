using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    void Update()
    {
        transform.Translate(Vector2.left * _movementSpeed * Time.deltaTime);
    }
}
