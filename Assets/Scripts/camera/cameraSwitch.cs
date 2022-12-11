using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class cameraSwitch : MonoBehaviour
{
    public Camera mainCamera;

    public Camera perspCamera;
    
    public GameObject cm;
    public CinemachineFreeLook cineM;

    public bool isMain;

    public Vector3 oldPos;
    public Vector3 newPos;

    [Range(0.1f, 1)] 
    public float lerpIntensity;
    
    
    // Start is called before the first frame update
    void Start()
    {
        perspCamera.enabled = false;
        perspCamera.GetComponent<perspectiveCamera>().enabled = false;
        isMain = true;
        perspCamera.transform.position = mainCamera.transform.position;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //perspChange();
            if (isMain)
            {
                isMain = false;
                cineM.enabled = false; //disable cinemachine
                perspCamera.GetComponent<perspectiveCamera>().enabled = true;
                perspCamera.enabled = true;
                mainCamera.enabled = false;
                perspCamera.transform.rotation = cm.transform.rotation;
                //StartCoroutine(LerpPosition(cm.transform.position,mainCamera.transform.position, lerpIntensity));
            }
            else
            {
                isMain = true;
                perspCamera.GetComponent<perspectiveCamera>().enabled = false;
                cineM.enabled = true;
                perspCamera.transform.position = mainCamera.transform.position;
                mainCamera.enabled = true;
                perspCamera.enabled = false;
                
            }
        }

        if (!isMain)
        {
            perspCamera.transform.rotation = cm.transform.rotation;
        }
    }

    public void perspChange()
    {
        if (isMain)
        {
            perspCamera.enabled = true;
            mainCamera.enabled = false;
            StartCoroutine(LerpPosition(cm.transform.position,mainCamera.transform.position, lerpIntensity));
        }
        else
        {
            mainCamera.enabled = true;
            perspCamera.enabled = false;
        }
        
    }
    
    IEnumerator LerpPosition(Vector3 targetPosition, Vector3 startPosition, float duration)
    {
        float time = 0; //how long it takes to lerp to targetPosition
        startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        Debug.Log("cam change ienumerator triggered");
    }
}
