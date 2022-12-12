using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //public menuController mc;
    [SerializeField]
    
    public float _melonGaugeCurr, _melonGaugeMax;
    public float _pomGaugeCurr, _pomGaugeMax;

    [SerializeField] public bool _canMelon, _canPom;
    
    
    public int fruitForm;
    // Start is called before the first frame update
    
    
    
    void Start()
    {
        //tea = 1; melon = 2; pom = 3
        fruitForm = 1;
        
        _melonGaugeMax = 85.0f;
        _pomGaugeMax = 85.0f;
        
        
        _melonGaugeCurr = 85.0f;
        _pomGaugeCurr = 85.0f;

    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
