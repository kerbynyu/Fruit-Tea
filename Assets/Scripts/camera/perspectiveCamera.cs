using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perspectiveCamera : MonoBehaviour
{
    public GameObject cm;
    public GameObject player;
    
    //public float sensitivity; //might change this to a range after figuring out settings stuff
    public float sensitivity = 2.0f;
    public float minTurnAngle = -75.0f;
    public float maxTurnAngle = 60.0f;
    private float rotX;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void Update()
    {
        float y = Input.GetAxis("Mouse X") * sensitivity;
        rotX += Input.GetAxis("Mouse Y") * sensitivity;
        
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle); //clamps vertical rotation
        
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
        
    }
}
