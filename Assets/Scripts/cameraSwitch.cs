using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class cameraSwitch : MonoBehaviour
{
    public Camera mainCamera;

    public Camera perspCamera;
    
    public GameObject cm;

    public bool isMain;

    public Vector3 oldPos;
    public Vector3 newPos;

    [Range(0.1f, 1)] 
    public float lerpIntensity;
    
    
    // Start is called before the first frame update
    void Start()
    {
        perspCamera.enabled = false;
        isMain = true;
        perspCamera.transform.position = mainCamera.transform.position;
    }

    public void perspChange()
    {
        if (isMain)
        {
            
        }
        StartCoroutine(LerpPosition(cm.transform.position,mainCamera.transform.position, lerpIntensity));
    }
    
    IEnumerator LerpPosition(Vector3 targetPosition, Vector3 startPosition, float duration)
    {
        float time = 0;
        Vector3 perspPos = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(perspPos, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
