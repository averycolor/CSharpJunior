using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ControllableLight : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private Alarm _alarm;

    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        UpdateColor();
    }

    private void UpdateColor()
    {
        _meshRenderer.material.SetColor("_EmissionColor", Color.Lerp(Color.black, _color, _alarm.NormalizedVolume));
    }
}
