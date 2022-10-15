using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorFade : MonoBehaviour
{
    [SerializeField] private Color _fadeColor;
    private Color _defaultColor;

    [SerializeField] private float _fadeTime;
    private float _fadeTimeElapsed;
    private float _fadeTimeNormalized => _fadeTimeElapsed / _fadeTime;

    private MeshRenderer _meshRenderer;

    private Coroutine _fadeJob;
    private Coroutine _reverseFadeJob;

    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultColor = _meshRenderer.material.color;
        _fadeJob = StartCoroutine(Fade());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Fade()
    {
        while (_fadeTimeNormalized < 1)
        {
            _fadeTimeElapsed += Time.deltaTime;
            _meshRenderer.material.color = Color.Lerp(_defaultColor, _fadeColor, _fadeTimeNormalized);
            yield return null;
        }
    }

    public IEnumerator ReverseFade()
    {
        while (_fadeTimeNormalized > 0)
        {
            _fadeTimeElapsed -= Time.deltaTime;
            _meshRenderer.material.color = Color.Lerp(_defaultColor, _fadeColor, _fadeTimeNormalized);
            yield return null;
        }
    }
}
