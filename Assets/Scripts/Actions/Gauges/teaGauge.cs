using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teaGauge : MonoBehaviour
{
    //aka our health bar

    [Header("Fruit Infusions")] [SerializeField]
    private fruitGauge _pomGauge;

    private fruitGauge _melonGauge;
    
    
    
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

    public void doubleSteep()
    {
        _teaGaugeCurr -= 25.0f;
        _melonGauge._fruitGaugeCurr += 35.0f;
        _pomGauge._fruitGaugeCurr += 35.0f;
        


    }
}
