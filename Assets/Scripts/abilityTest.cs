using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilityTest : MonoBehaviour
{

    public GameObject currentHB;
    public GameObject launchUpHB;
    public GameObject launchDownHB;
    public GameObject splashDownHB;

    public float destroyTime = 0.3f;

    private float _timer;
    private float _holdDur = 0.3f;
    

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            waterSplash(); 
            //need a coroutine for the move disabler
            player.GetComponent<ThirdPersonMovement>().enabled = false;
            StartCoroutine(DestroyHB());
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //GetComponent<cameraSwitch>().perspChange();
                StartCoroutine(DestroyHB());
                
            }
            player.GetComponent<ThirdPersonMovement>().enabled = true;
        }

        
    }

    void waterSplash()
    {
        //prefab, position, rotation, parent
        currentHB = Instantiate(launchUpHB, player.transform.position, player.transform.rotation, player.transform);
        
    }
    
    IEnumerator DestroyHB()
    {
        yield return new WaitForSeconds(destroyTime);
        Debug.Log("destroyed");
        Destroy(currentHB);
    }
}
