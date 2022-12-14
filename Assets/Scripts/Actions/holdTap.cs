using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class holdTap : MonoBehaviour
{
    public AbilityControls _ac;

    
    
    [SerializeField]
    [Header("Actions")]
    private InputActionReference _abilityReference, _NAReference;

    private void Awake()
    {
        //creates new instance of the ability controls
        _ac = new AbilityControls();
    }

    private void OnEnable()
    {
        _abilityReference.action.Enable();
        _NAReference.action.Enable();
    }

    private void OnDisable()
    {
        _abilityReference.action.Disable();
        _NAReference.action.Disable();
    }

    private void Start()
    {
        //this first if statement might not be necessary but we'll see
        if (!(_abilityReference.action.interactions.Contains("Hold") &&
              _abilityReference.action.interactions.Contains("Tap")))
        {
            
            return;
        }

        _abilityReference.action.started += context =>
        {
            if (context.interaction is TapInteraction)
            {
                Debug.Log("tap started");

            }
            else if (context.interaction is HoldInteraction)
            {
                Debug.Log("hold started");
            }
        };
        _abilityReference.action.performed += context =>
        {
            if (context.interaction is TapInteraction)
            {
                Debug.Log("tap done");
            }
            else if (context.interaction is HoldInteraction)
            {
                Debug.Log("hold(ing?)");
            }

        };

        _abilityReference.action.canceled += context =>
        {
            if (context.interaction is TapInteraction)
            {
                Debug.Log("tap cancelled");
            }
            else if (context.interaction is HoldInteraction)
            {
                Debug.Log("holding cancelled");
            }
        };

    }
}
