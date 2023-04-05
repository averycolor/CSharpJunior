using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RandomizedValue
{
    [field: SerializeField] public float BaseValue { get; private set; }
    [SerializeField, Range(0f, 1f)] private float _randomnessLevel;

    private float _frozenValue;
    private bool _isFrozen;

    public float Value { 
        get 
        { 
            return _isFrozen? _frozenValue : BaseValue * (1.0f + Random.Range(-_randomnessLevel, _randomnessLevel)); 
        }
        set
        {
            BaseValue = value;

            if (_isFrozen)
            {
                _frozenValue = value;
            }
        }
    }
    public int RoundedValue { get { return Mathf.RoundToInt(_isFrozen? _frozenValue : Value); } }

    public void Freeze()
    {
        _frozenValue = Value;
        _isFrozen = true;
    }

    public void Unfreeze()
    {
        _isFrozen = false;
    }
}
