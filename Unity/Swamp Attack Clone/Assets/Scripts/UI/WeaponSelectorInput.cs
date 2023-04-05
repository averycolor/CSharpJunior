using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class WeaponSelectorInput : MonoBehaviour
{
    [SerializeField] private Button _previousButton;
    [SerializeField] private Button _nextButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _previousButton.onClick?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _nextButton.onClick?.Invoke();
        }
    }
}
