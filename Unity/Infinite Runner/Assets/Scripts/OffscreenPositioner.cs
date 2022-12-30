using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Side
{
    Left, Right
}

public class OffscreenPositioner : MonoBehaviour
{
    [SerializeField] private Side _side;
    [SerializeField] private Vector3 _additionalOffset;

    private void Start()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint((_side == Side.Right ? Vector3.right : Vector3.zero) * Camera.main.pixelWidth + Vector3.up * Camera.main.pixelHeight / 2);
        position.z = 0f;

        transform.position = position + _additionalOffset;
    }
}
