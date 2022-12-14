using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class menuController : MonoBehaviour
{
    [Header("General Info")]
    public PlayerManager pm;
    //this is bullshit cus it changes in update
    
    
    [Header("Angle Calculation")]
    public CinemachineFreeLook cam;
    public float angle;
    public Vector3 initialVector;
    private float[] camSpeed;
    
    [Header("Infusions")]
    public infusionAbstract teaInfusion;
    public infusionAbstract melonInfusion;
    public infusionAbstract pomInfusion;
    [Space(10)] 
    [SerializeField] 
    private int currentForm;
    public int nextForm; //is taken by pm to see if we can even switch to the desired form
    private infusionAbstract _toSet; //will be inserted to pm if the above check passes
    
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
                
            initialVector = Input.mousePosition;
        }
        
        if (Input.GetKey(KeyCode.Tab))
        {
            CalculateAngle();

            if (angle < 135.0 && angle >= 45.0)
            {
                //Debug.Log("Tea! " + angle);
                nextForm = 1;
                _toSet = teaInfusion;

            }
            else if (angle < 270.0 && angle >= 135)
            {
                //Debug.Log("Pom! " + angle);
                nextForm = 2;
                _toSet = pomInfusion;
            }
            else if (angle < 45 && angle >= 0 || angle >= 270 && angle < 360.0)
            {
                Debug.Log("Melon! " + angle);
                nextForm = 3;
                _toSet = melonInfusion;
            }
            
        }
        
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            SetSpeed(camSpeed[0], camSpeed[1]);

            //set the player infusion to whatever we hovered over
            
            
            pm.infusionCurr = _toSet;
            pm.fruitForm = nextForm;
            currentForm = nextForm;
        }
    }

    void CalculateAngle()
    {
        Vector2 vi = Vector2.left;
        //normalize to get a directional vector, like Vector3.left
        Vector2 vn = ((Vector2)(Input.mousePosition - initialVector)).normalized;
        
        angle = Vector2.SignedAngle(vi, vn); //counter clockwise, negative is up, positive is down
        if (angle < 0) angle += 360;
        angle = 360 - angle; //90 is vertical

        //Debug.Log($"angleVector: {vn}, angle: {angle}");
    }
    
}
