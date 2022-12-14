using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerManager : MonoBehaviour
{
    
    public menuController mc;
    
    [SerializeField] public bool _canMelon, _canPom;

    public int fruitForm;
    // Start is called before the first frame update

    [Header("current infusion")] [SerializeField]
    public infusionAbstract infusionCurr;
    
    [SerializeField]
    [Header("Actions")]
    private InputActionReference _abilityReference, _NAReference;

    private void OnEnable()
    {
        _abilityReference.action.Enable();
        _NAReference.action.Enable();
    }
    
    
    void Start()
    {
        //tea = 1; melon = 2; pom = 3
        fruitForm = 1;
        infusionCurr = mc.teaInfusion;
        
        // _melonGaugeMax = 85.0f;
        // _pomGaugeMax = 85.0f;
        //
        //
        // _melonGaugeCurr = 85.0f;
        // _pomGaugeCurr = 85.0f;

        //tap/hold detection statements
        if (!(_abilityReference.action.interactions.Contains("Hold") &&
              _abilityReference.action.interactions.Contains("Tap")))
        {
            
            return;
        }

        //ability tap/holds
        _abilityReference.action.started += context =>
        {
            if (context.interaction is TapInteraction)
            {
                infusionCurr._eTap();
                //Debug.Log("etap started");

            }
            else if (context.interaction is HoldInteraction)
            {
                
                //Debug.Log("ehold started");
            }
        };
        _abilityReference.action.performed += context =>
        {
            if (context.interaction is TapInteraction)
            {
                //performed is triggered after you let go of the button
                //Debug.Log("etap done");
            }
            else if (context.interaction is HoldInteraction)
            {
                infusionCurr._eHold();
                //Debug.Log("ehold(ing?)");
            }

        };
        _abilityReference.action.canceled += context =>
        {
            if (context.interaction is HoldInteraction)
            {
                infusionCurr._eHoldStop();
                //Debug.Log("eholding cancelled");
            }
        };
        
        //normal attack tap/holds
        _NAReference.action.started += context =>
        {
            if (context.interaction is TapInteraction)
            {
                infusionCurr._nAttackTap();
                //Debug.Log("NAtap started");

            }
            else if (context.interaction is HoldInteraction)
            {
                //Debug.Log("NAhold started");
            }
        };
        _NAReference.action.performed += context =>
        {
            if (context.interaction is TapInteraction)
            {
                
                //Debug.Log("NAtap done");
            }
            else if (context.interaction is HoldInteraction)
            {
                infusionCurr._nAttackHold();
                //Debug.Log("NAhold(ing?)");
            }

        };

        _NAReference.action.canceled += context =>
        {
            if (context.interaction is HoldInteraction)
            {
                //Debug.Log("NAholding cancelled");
            }
        };
        
    }

    // Update is called once per frame
    // public bool _canFruit(int fruitCurr)
    // {
    //     fruitForm.
    // }
}
