using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemySpriteSelector : MonoBehaviour
{
    [SerializeField] private Sprite[] _possibleSprites;

    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        if (_spriteRenderer == null)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        int spriteIndex = Random.Range(0, _possibleSprites.Length);
        _spriteRenderer.sprite = _possibleSprites[spriteIndex];
    }
}
