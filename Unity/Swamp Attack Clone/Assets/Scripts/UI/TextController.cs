using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public abstract class TextController : MonoBehaviour
{
    private TMP_Text _text;

    protected abstract string Text { get; }

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _text.text = Text;
    }
}
