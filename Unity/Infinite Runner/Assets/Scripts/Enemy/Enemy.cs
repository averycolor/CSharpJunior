using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(1);
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
