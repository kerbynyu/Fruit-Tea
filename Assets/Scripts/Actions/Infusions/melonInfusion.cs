using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class melonInfusion : infusionAbstract
{
    [Header("Player Info")] 
    [SerializeField]
    public GameObject _player;
    public Vector3 _playerPos;
    private Vector3 _prevHeight;
    [Space(10)]
    [SerializeField]
    private GameObject _tapPos, _upPos;
    private Vector3 _launchPos; //we get this from the raycast
    //private float launchHeight;
    
    [Space(10)] 
    [SerializeField]
    private bool _jumped;
    
    [Space(10)]
    
    [Header("Hitboxes")]
    [SerializeField]
    private GameObject bigSplashHB;
    private GameObject smallSplashHB;
    private Vector3 floorHit;
    public void Start()
    {
        _playerPos = _player.transform.position;
        _prevHeight = _player.transform.position;
    }

    public void Update()
    {
        _player.transform.position = _playerPos;
    }

    public override void _eTap()
    {
        Debug.Log("melon ability tap");
        _playerPos = _player.transform.position;
        _playerPos += _player.transform.forward * 2f;
        ;

    }

    public override void _eHold()
    {
        Debug.Log("melon ability hold");
        _jumped = true;
        _playerPos = _player.transform.position;
        _playerPos.y += _upPos.transform.position.y;
        _player.GetComponent<ThirdPersonMovement>().enabled = false;
        
    }
    
    public override void _eHoldStop()
    {
        Debug.Log("melon ability hold stop");
        if (!_jumped)
        {
            return;
        }
        //sets the player height back to where you started
        _playerPos = _player.transform.position;
        //_playerPos.y = _prevHeight.y; //THIS IS TEMPORARY
        _jumped = false;
        //
        //raycast pos stuff
        RaycastFloor(50f, _player.transform);
        _playerPos = floorHit +  new Vector3(0,1,0);
        //_player.GetComponent<ThirdPersonMovement>().enabled = true;

    }

    public void RaycastFloor(float distanceToCheck, Transform whereFrom)
    {
        //raycasts to floor/downward
        Ray ray = new Ray(whereFrom.position, -whereFrom.up); //checks negative up for down
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
}
