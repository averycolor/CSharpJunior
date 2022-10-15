using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LinearColorFade : MonoBehaviour
{
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _duration;
    private bool _isFading;
    private float _timeElapsed;
    private SpriteRenderer _spriteRenderer;
    private Color _previousColor;

    // Start is called before the first frame update
    void Start()
    {
        _isFading = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _previousColor = _spriteRenderer.color;
        Fade();
    }

    public void Fade()
    {
        _isFading = true;
        _timeElapsed = 0;
    }

    public void Update()
    {
        if (_isFading)
        {
            float normalizedFadeTime = _timeElapsed / _duration;

            if (normalizedFadeTime < 1)
            {
                _spriteRenderer.color = Color.Lerp(_previousColor, _targetColor, normalizedFadeTime);
                _timeElapsed += Time.deltaTime;
            }
            else
            {
                _isFading = false;
                _timeElapsed = 0;
            }
        }
    }
}
