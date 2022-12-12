using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class menuController : MonoBehaviour
{
    public CinemachineFreeLook cam;
    public PlayerManager pm;
    

    public float angle;
    public Vector3 initalVector;

    public int currentForm;
    
    private float[] camSpeed;
    
    
    //for debug
    private Vector3 worldPos;
    
    private void Awake() 
    {
        camSpeed = new[] { cam.m_XAxis.m_MaxSpeed, cam.m_YAxis.m_MaxSpeed };
    }
    
    void SetSpeed(float x, float y)
    {
        cam.m_XAxis.m_MaxSpeed = x;
        cam.m_YAxis.m_MaxSpeed = y;
    }
            
    private void Start()
    {
        currentForm = 1;
    }        

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SetSpeed(0, 0);
                
            initalVector = Input.mousePosition;
        }
        
        if (Input.GetKey(KeyCode.Tab))
        {
            CalculateAngle();

            if (angle < 135.0 && angle >= 45.0)
            {
                Debug.Log("Tea! " + angle);
                pm.fruitForm = 1;
                
            }
            else if (angle < 270.0 && angle >= 135)
            {
                Debug.Log("Pom! " + angle);
                pm.fruitForm = 2;
            }
            else if (angle < 45 && angle >= 0 || angle >= 270 && angle < 360.0)
            {
                Debug.Log("Melon! " + angle);
                pm.fruitForm = 3;
            }
            
            
        }
        
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            SetSpeed(camSpeed[0], camSpeed[1]);
            
            currentForm = pm.fruitForm;
        }
    }

    void CalculateAngle()
    {
        Vector2 vi = Vector2.left;
        //normalize to get a directional vector, like Vector3.left
        Vector2 vn = ((Vector2)(Input.mousePosition - initalVector)).normalized;
        
        angle = Vector2.SignedAngle(vi, vn); //counter clockwise, negative is up, positive is down
        if (angle < 0) angle += 360;
        angle = 360 - angle; //90 is vertical

        Debug.Log($"angleVector: {vn}, angle: {angle}");
    }
    
    
    
    
}
