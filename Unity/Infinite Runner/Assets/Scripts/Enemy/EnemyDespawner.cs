using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.gameObject.SetActive(false);
        }
    }
}
