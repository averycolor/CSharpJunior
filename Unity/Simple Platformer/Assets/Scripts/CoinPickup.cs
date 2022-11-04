using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private int _coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;

        if (other.TryGetComponent(out Coin coin))
        {
            Destroy(other.gameObject);
            _coins++;
            print(_coins);
        }
    }
}
