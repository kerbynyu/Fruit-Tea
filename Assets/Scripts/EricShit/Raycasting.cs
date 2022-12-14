using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    public GameObject[] pipPositions;
    private float i; //which pip we are on
    public GameObject firedPip;
    [SerializeField] float pipSpeed;
    public Vector3 enemyHit;
    public Vector3 rigidHit;
    public Vector3 floorHit;

    private GameObject shot;
    public bool shooting;
    private Vector3 nearestEnemy;
    public List<Collider> listNear;
    public PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        pipPositions = GameObject.FindGameObjectsWithTag("Pip"); //easiest way without having to drag all pips
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerManager.fruitForm == 2)
        {
            //Raycast for an enemy
            if (Input.GetMouseButtonUp(0))
            {
                //RaycastFloor(100f);
                //RaycastRigid(100f);
                for (int j = 0; j < pipPositions.Length; j++)
                {
                    if (pipPositions[j].gameObject.name == ("Pip" + i) && shooting)
                    {
                        shot = Instantiate(firedPip, pipPositions[j].transform.position, pipPositions[j].transform.rotation);

                        RaycastEnemy(100f, transform); //can alter the distance to check. the transform is to help indicate where we draw raycast from
                        shot.GetComponent<PipDestroy>().hold = pipPositions[j]; //set position to hold ats position to the pip location
                        shooting = false;

                    }
                }

                i++;
                if (i > 5) //more than the 5 pip positions, reset to shoot from first
                {
                    i = 1;
                }


            }
        }


        if (shot != null)
        {
            
                if (enemyHit != Vector3.zero)//We only lerp bullets IF u are raycast from player hits an enemy
                {
                    shot.GetComponent<PipDestroy>().whereTo = enemyHit;
                    shot.GetComponent<PipDestroy>().speed = pipSpeed;
                    shot.GetComponent<PipDestroy>().CanShoot();
                }
                else //else we did not have successful hit
                {
                shot.GetComponent<PipDestroy>().whereTo = nearestEnemy;
                shot.GetComponent<PipDestroy>().speed = pipSpeed;
                shot.GetComponent<PipDestroy>().CanShoot();

            }


            //there is no nearby enemy then we can just deny the shot
        }



    }

   

    private void OnTriggerStay(Collider other) //now we use big sphere collider to check for nearest enemy instead
    {
        Collider[] enemiesClose = Physics.OverlapSphere(transform.position + new Vector3(0, 0, 7), 50);
        listNear = new List<Collider>(enemiesClose); //create constant list of nearby Enemies


        if (listNear.Contains(other) && other.gameObject.tag == "Enemy") //check if we have any enemies in our close circle
        {
            Debug.Log("ENEMI");
            shooting = true;
            nearestEnemy = other.gameObject.transform.position;

        } 

        
    }

   




    public void RaycastEnemy(float distanceToCheck, Transform whereFrom)
    {
        Ray ray = new Ray(whereFrom.position, whereFrom.forward);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, distanceToCheck))
        {
            // The Ray hit something!
            if (hitData.transform.gameObject.tag == "Enemy") //if we hit da enemy
            {  //This is the tag for all enemies ("Target")

                //Debug.Log(hitData.transform.position); //position of whatever we hit
                enemyHit = hitData.transform.position;
            } else
            {
                enemyHit = Vector3.zero;
            }

        }
    }

    public void RaycastFloor(float distanceToCheck, Transform whereFrom)
    {
        //raycasts to floor/downward
        Ray ray = new Ray(whereFrom.position, -whereFrom.up + whereFrom.forward); //checks negative up for down
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, distanceToCheck))
        {
            if (hitData.transform.gameObject.tag == "Floor") //does what I hit have a rigidbody?
            {
                //Debug.Log(hitData.point); //returns exact world position of ray endpoint when we raycast
                floorHit = hitData.point;
            }
            else
            {
                floorHit = Vector3.zero;
            }

        }        
    }

    public void RaycastRigid(float distanceToCheck, Transform whereFrom)
    {
        //raycasts forward to anything with rigidbody
        Ray ray = new Ray(whereFrom.position, whereFrom.forward); //checks negative up for down
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, distanceToCheck))
        {
            if (hitData.rigidbody != null) //does what I hit have a rigidbody?
            {
                //Debug.Log(hitData.point); //returns exact world position of ray endpoint when we raycast
                rigidHit = hitData.point;
            }
            else
            {
                rigidHit = Vector3.zero;
            }

        }



    }



}
