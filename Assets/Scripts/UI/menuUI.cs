using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class menuUI : MonoBehaviour
{
    public menuController mc;
    [Space(10)]
    public RawImage UIbase;
    public RawImage pomGrey;
    public RawImage melonGrey;
    public RawImage teaTop;
    public RawImage melonLeft;
    public RawImage pomRight;

    //public RawImage activeObj;
    //public RawImage prevObj;

    public int currUI;
    void Start()
    {
        UIbase.enabled = false;
        teaTop.enabled = false;
        melonLeft.enabled = false;
        pomRight.enabled = false;
        //activeObj = null;
        //prevObj = null;
    }

    // Update is called once per frame
    void Update()
    {
        currUI = mc.nextForm;
        if (Input.GetKey(KeyCode.Tab))
        {
            UIbase.enabled = true;
            //activeObj.enabled = true;
            //prevObj = teaTop;
            if (currUI == 1)
            {
                // prevObj.enabled = false;
                // activeObj = teaTop;
                // activeObj.enabled = true;
                // Debug.Log("current UI1");
                // prevObj = activeObj;
                
                
                melonLeft.enabled = false;
                pomRight.enabled = false;
                teaTop.enabled = true;
            }
            else if (currUI == 2)
            {
                // prevObj.enabled = false;
                // activeObj = pomRight;
                // activeObj.enabled = true;
                // Debug.Log("current UI2");
                // //activeObj.enabled = true;
                // prevObj = activeObj;
                
                teaTop.enabled = false;
                melonLeft.enabled = false;
                pomRight.enabled = true;
                
            }
            else
            {
                // prevObj.enabled = false;
                // activeObj = melonLeft;
                // activeObj.enabled = true;
                // Debug.Log("current UI3");
                // //activeObj.enabled = true;
                // prevObj = activeObj;
                teaTop.enabled = false;
                pomRight.enabled = false;
                melonLeft.enabled = true;
                
            }

        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            UIbase.enabled = false;
            // prevObj.enabled = false;
            // activeObj.enabled = false;
            teaTop.enabled = false;
            pomRight.enabled = false;
            melonLeft.enabled = false;
            
        }
        

    }
}
