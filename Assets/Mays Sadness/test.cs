using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public RectTransform radialMenu;
    public RectTransform startDebug;
    public RectTransform endDebug;
    
    public float angle;
    public Vector3 initalVector;
    
    //for debug
    private Vector3 worldPos;
    // public GameObject o;
    
    
    // Update is called once per frame
    void Update()
    {
        //would be tab
        if (Input.GetKeyDown(KeyCode.A))
        {
            initalVector = Input.mousePosition;
            //Debug menu
            radialMenu.position = initalVector;
            
            //Debug it in the scene (not really part of code)
            // Vector3 pos = Camera.main.ScreenToWorldPoint(initalVector);
            // worldPos = new Vector3(pos.x, pos.y, 0);
            // Instantiate(o, worldPos, Quaternion.identity);
            // Debug.DrawLine(worldPos + Vector3.left, worldPos, Color.green, 100f);
        }
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            CalculateAngle();
        }
    }

    void CalculateAngle()
    {
        Vector3 vi = Vector3.left;
        //normalize to get a directional vector, like Vector3.left
        Vector3 vn = (Input.mousePosition - initalVector).normalized;
        
        angle = Vector2.SignedAngle(vi, vn); //counter clockwise, negative is up, positive is down
        if (angle < 0) angle += 360;
        angle = 360 - angle;
        
        //Debug angle
        startDebug.position = initalVector + vi*50;
        endDebug.position = initalVector + vn * 50;
        Debug.DrawLine(radialMenu.position, endDebug.position, Color.red, 100f);
        Debug.DrawLine(radialMenu.position, startDebug.position, Color.green, 100f);
    }
    
}
