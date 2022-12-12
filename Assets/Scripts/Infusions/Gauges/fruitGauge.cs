using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitGauge : MonoBehaviour
{
    [Header("General Info")] 
    public float _fruitGaugeMax;

    public float _fruitGaugeCurr;
    
    
    
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
}
