using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class melonInfusion : infusionAbstract
{
    [Header("Player Info")]
    //[SerializeField]
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
    public bool normalize;
    public void Start()
    {
        _playerPos = _player.transform.position;
        _prevHeight = _player.transform.position;
        normalize = true;
    }

    public void Update()
    {
        if (!Input.GetKey(KeyCode.E) && !Input.GetKeyUp(KeyCode.E) && normalize)
        {
            _playerPos = _player.transform.position;
        }
        _player.transform.position = Vector3.Lerp(_player.transform.position, _playerPos, 0.015f);
    }

    public override void _eTap()
    {
        StopAllCoroutines();
        Debug.Log("melon ability tap");
        //_player.GetComponent<ThirdPersonMovement>().enabled = false;
        normalize = false;
        _playerPos += _player.transform.forward * 10f;
        StartCoroutine(Timed());


    }

    public override void _eHold()
    {
        //StopAllCoroutines();
        Debug.Log("melon ability hold");
        _jumped = true;
        normalize = true;
        _playerPos = _player.transform.position;
        //StartCoroutine(LerpUp());
        _playerPos.y += _upPos.transform.position.y + 20f;
        //_player.GetComponent<ThirdPersonMovement>().enabled = false;
        //StartCoroutine(Timed2());
    }

    public override void _eHoldStop()
    {
        StopAllCoroutines();
        Debug.Log("melon ability hold stop");
        if (!_jumped)
        {
            return;
        }
        //sets the player height back to where you started
        //_playerPos = _player.transform.position;
        //_playerPos.y = _prevHeight.y; //THIS IS TEMPORARY
        _jumped = false;
        //raycast pos stuff
        normalize = false;
        RaycastFloor(70f, _player.transform);
        _playerPos = floorHit + new Vector3(0, 1, 0);
        StartCoroutine(Timed());

        //_player.GetComponent<ThirdPersonMovement>().enabled = true; //FIX PLEASE, NEED TO ADD

    }

    IEnumerator Timed()
    {


        yield return new WaitForSeconds(0.5f);
        normalize = true;
        _player.GetComponent<ThirdPersonMovement>().enabled = true;

    }

    IEnumerator Timed2()
    {


        yield return new WaitForSeconds(0.5f);
        _player.GetComponent<ThirdPersonMovement>().enabled = false;

    }

    public void RaycastFloor(float distanceToCheck, Transform whereFrom)
    {
        //raycasts to floor/downward
        Ray ray = new Ray(whereFrom.position, -whereFrom.up); //checks negative up for down
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, distanceToCheck))
        {
            if (hitData.transform.gameObject.tag == "Floor" || hitData.transform.gameObject.tag == "Wall" || distanceToCheck > 0) //does what I hit have a rigidbody?
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
