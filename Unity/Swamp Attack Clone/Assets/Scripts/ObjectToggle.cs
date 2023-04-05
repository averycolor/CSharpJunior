using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ObjectToggle : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private bool _isToggled;

    public void Toggle()
    {
        _isToggled = !_isToggled;
        _target.gameObject.SetActive(_isToggled);
    }
}
