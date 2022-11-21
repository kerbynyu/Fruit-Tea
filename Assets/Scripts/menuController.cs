using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{
    public PlayerManager pm;

    public Form1 f1;

    public Form2 f2;

    public Form3 f3;
    
    // public RectTransform radialMenu;
    // public RectTransform startDebug;
    // public RectTransform endDebug;

    
    public float angle;
    public Vector3 initalVector;

    public int currentForm;
    
    //for debug
    private Vector3 worldPos;
    //public GameObject o;

    private void Start()
    {
        currentForm = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //would be tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //initalVector = Camera.main.WorldToScreenPoint(Input.mousePosition);
            initalVector = Input.mousePosition;
            
            //Debug it in the scene (not really part of code)
            Vector3 pos = Camera.main.WorldToScreenPoint(initalVector);
            worldPos = new Vector3(pos.x, pos.y, 0);
            //Instantiate(o, worldPos, Quaternion.identity);
            //Debug.DrawLine(worldPos + Vector3.left, worldPos, Color.green, 100f);
            
            //add code to update gradient
        }
        
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            CalculateAngle();
            if (angle < 330.0 && angle >= 210.0)
            {
                Debug.Log("Tea! " + angle);
                pm.form = 1;
                
            }
            else if (angle < 210.0 && angle >= 90)
            {
                Debug.Log("Pom! " + angle);
                pm.form = 2;
            }
            else if (angle < 90 && angle >= 0 || angle >= 330 && angle < 360.0)
            {
                Debug.Log("Melon! " + angle);
                pm.form = 3;
            }
            
            currentForm = pm.form;
        }
    }

    void CalculateAngle()
    {
        Vector3 vi = Vector3.left;
        //normalize to get a directional vector, like Vector3.left
        Vector3 vn = (Input.mousePosition - initalVector).normalized;
        
        // angle = Vector2.SignedAngle(vi, vn); //counter clockwise, negative is up, positive is down
        // if (angle < 0) angle += 360;
        
        angle = Vector2.SignedAngle(vi, vn); //counter clockwise, negative is up, positive is down
        if (angle < 0) angle += 360;
        angle = 360 - angle;
        
        //Debug angle
        //Debug.DrawLine(worldPos, worldPos + vn, Color.red, 100f);
        //Debug.Log(angle);
    }
    
    
    
    
}
