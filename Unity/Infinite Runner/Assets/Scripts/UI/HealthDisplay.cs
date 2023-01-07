using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _hearts;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
        _hearts = new List<Heart>();
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        for (int i = 0; i < _hearts.Count; i++) 
        {
            Heart heart = _hearts[i];
            Destroy(heart.gameObject);
        }

        _hearts = new List<Heart>();

        for (int i = 0; i < value; i++)
        {
            Heart newHeart = Instantiate(_heartTemplate, transform);
            _hearts.Add(newHeart);
        }
    }
}
