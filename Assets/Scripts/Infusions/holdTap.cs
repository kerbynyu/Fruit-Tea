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
    private InputActionReference _actionReference;

    private void Awake()
    {
        //creates new instance of the ability controls
        _ac = new AbilityControls();
    }

    private void OnEnable()
    {
        _actionReference.action.Enable();
    }

    private void OnDisable()
    {
        _actionReference.action.Disable();
    }

    private void Start()
    {
        //this first if statement might not be necessary but we'll see
        if (!(_actionReference.action.interactions.Contains("Hold") &&
              _actionReference.action.interactions.Contains("Tap")))
        {
            return;
        }

        _actionReference.action.started += context =>
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
        _actionReference.action.performed += context =>
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

        _actionReference.action.canceled += context =>
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
