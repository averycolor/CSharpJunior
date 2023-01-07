using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _fadeDuration;

    private Image _image;
    private bool _shown;

    public bool Shown => _shown;

    private event UnityAction<float> _fadeComplete;

    private void OnEnable()
    {
        _fadeComplete += OnFadeComplete;
        _shown = true;
    }

    private void OnDisable()
    {
        _fadeComplete -= OnFadeComplete;
    }

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void Hide()
    {
        FadeAlpha(1f, 0f, _fadeDuration);
        _shown = false;
    }

    public void Show()
    {
        FadeAlpha(0f, 1f, _fadeDuration);
        _shown = true;
    }

    private void OnFadeComplete(float value)
    {
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, value);
    }

    private IEnumerator FadeAlpha(float from, float to, float duration)
    {
        float elapsedTime = 0f;
        float normalizedElapsedTime = elapsedTime / duration;

        while (normalizedElapsedTime < 1)
        {
            elapsedTime += Time.deltaTime;
            normalizedElapsedTime = elapsedTime / duration;

            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, Mathf.Lerp(from, to, normalizedElapsedTime));

            yield return null;
        }

        _fadeComplete?.Invoke(elapsedTime);
    }
}
