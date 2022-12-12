using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teaGauge : MonoBehaviour
{
    //aka our health bar
    
    [Header("Fruit Infusions")]
    
    
    
    [Header("Tea Info")]
    public float _teaGaugeCurr, _teaGaugeMax;
    
    // Start is called before the first frame update
    void Start()
    {
        _teaGaugeMax = 150.0f;
        _teaGaugeCurr = 150.0f;
    }

    public bool canSteep()
    {
        float ratio = _teaGaugeCurr / _teaGaugeMax;
        
        //if health percentage is less than 15%, then you cannot steep 
        if (ratio <= 0.15f)
        {
            return false;
        }

        return true;
    }
}
