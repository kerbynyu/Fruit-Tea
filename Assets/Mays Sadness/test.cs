using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float angle;
    public Vector3 initalVector;
    
    //for debug
    private Vector3 worldPos;
    public GameObject o;
    
    // Update is called once per frame
    void Update()
    {
        //would be tab
        if (Input.GetKeyDown(KeyCode.A))
        {
            initalVector = Input.mousePosition;
            
            //Debug it in the scene (not really part of code)
            Vector3 pos = Camera.main.ScreenToWorldPoint(initalVector);
            worldPos = new Vector3(pos.x, pos.y, 0);
            Instantiate(o, worldPos, Quaternion.identity);
            Debug.DrawLine(worldPos + Vector3.left, worldPos, Color.green, 100f);
        }
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            CalculateAngle();
            if (angle < 330.0 && angle >= 210.0)
            {
                Debug.Log("Tea!");
            }
            else if (angle < 210.0 && angle >= 90)
            {
                Debug.Log("Pom!");
            }
            else if (angle < 90 && angle >= 0 || angle >= 330 && angle < 360.0)
            {
                Debug.Log("Melon!");
            }
        }
    }

    void CalculateAngle()
    {
        Vector3 vi = Vector3.left;
        //normalize to get a directional vector, like Vector3.left
        Vector3 vn = (Input.mousePosition - initalVector).normalized;
        
        angle = Vector2.SignedAngle(vi, vn); //counter clockwise, negative is up, positive is down
        if (angle < 0) angle += 360;
        
        //Debug angle
        Debug.DrawLine(worldPos, worldPos + vn, Color.red, 100f);
        //Debug.Log(angle);
    }
    
}
