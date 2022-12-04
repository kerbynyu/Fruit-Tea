using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Raycast for an enemy
        if (Input.GetKeyDown(KeyCode.R))
        {
            //RaycastEnemy(10f);
            //RaycastFloor(100f);
            RaycastRigid(100f);
        }
    }

    public void RaycastEnemy(float distanceToCheck)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, distanceToCheck))
        {
            // The Ray hit something!
            if (hitData.transform.gameObject.tag == "Target") //if we hit da enemy
            {  //This is the tag for all enemies ("Target")

                Debug.Log(hitData.transform.position); //position of whatever we hit

            }

        }
    }

    public void RaycastFloor(float distanceToCheck)
    {
        //raycasts to floor/downward
        Ray ray = new Ray(transform.position, -transform.up); //checks negative up for down
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, distanceToCheck))
        {
            if (hitData.transform.gameObject.tag == "Floor") //does what I hit have a rigidbody?
            {
                Debug.Log(hitData.point); //returns exact world position of ray endpoint when we raycast
                
            }

        }        
    }

    public void RaycastRigid(float distanceToCheck)
    {
        //raycasts forward to anything with rigidbody
        Ray ray = new Ray(transform.position, transform.forward); //checks negative up for down
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, distanceToCheck))
        {
            if (hitData.rigidbody != null) //does what I hit have a rigidbody?
            {
                Debug.Log(hitData.point); //returns exact world position of ray endpoint when we raycast

            }

        }



    }



}
