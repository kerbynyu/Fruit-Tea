using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class melonInfusion : infusionAbstract
{
    [Header("Player Info")] 
    [SerializeField]
    private GameObject _player;
    private Vector3 _playerPos;
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
    
    public void Start()
    {
        //_playerPos = _player.transform.position;
        _prevHeight = _player.transform.position;

    }

    public override void _eTap()
    {
        Debug.Log("melon ability tap");
        _player.transform.position = _tapPos.transform.position;
    }

    public override void _eHold()
    {
        Debug.Log("melon ability hold");
        _jumped = true;
        _playerPos.y = _upPos.transform.position.y;
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
        _playerPos.y = _prevHeight.y; //THIS IS TEMPORARY
        _player.GetComponent<ThirdPersonMovement>().enabled = true;
        _jumped = false;
        //
        //raycast pos stuff

    }
}
