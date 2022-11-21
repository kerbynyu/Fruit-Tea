using System.Collections;
using Cinemachine;
using UnityEngine;

public class cameratest : MonoBehaviour
{
    //this script is placed on a empty object in scene.
    public CinemachineFreeLook c1; //3rd person camera
    public Transform player;
    private bool inMenu;
    private float returnSpeed = 20;
    public void Update()
    {
        //maybe opening menu could be an event, thus subscribe instead
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inMenu = true;
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            StartCoroutine(FollowPlayer());
        }

        if (!inMenu)
        {
            transform.position = player.position;
        }
    }

    public IEnumerator FollowPlayer()
    {
        //probably have this finish before letting player move again, though it works fine as is too
        while (transform.position != player.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                player.transform.position, returnSpeed * Time.deltaTime);
            yield return null;
        }

        inMenu = false;
    }
}
