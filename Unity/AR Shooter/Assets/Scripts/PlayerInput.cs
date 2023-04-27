using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction ChargeShot;
    public event UnityAction ReleaseShot;

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() == false) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChargeShot?.Invoke();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                ReleaseShot?.Invoke();
            } 
        }
    }
}
