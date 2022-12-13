using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitGauge : MonoBehaviour
{
    [Header("General Info")] 
    [SerializeField]
    float _fruitGaugeMax;
    float _fruitGaugeCurr;
    
    
    
    void Start()
    {
        
    }

    public bool _canAbility(float cost)
    {
        float afterCalc = _fruitGaugeCurr - cost;
        
        //if theres not enough energy left 
        if (afterCalc < 0)
        {
            return false;
        }
        _fruitGaugeCurr = afterCalc;
        return true;
    }

    
    //setters for fruit gauge values
    public void _setMax(float _newMax)
    {
        _fruitGaugeMax = _newMax;
    }

    public void _setCurr(float _newCurr)
    {
        _fruitGaugeCurr = _newCurr;
    }
}
