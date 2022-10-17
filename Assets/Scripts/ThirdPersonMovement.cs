using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform camera;
    private Vector3 _playerVelocity;

    public float speed;
    public float speedMax;
    public float speedAcc;
    public float speedGroundDacc;
    public float speedAirDacc;

    public float turnSmooth = 0.1f;
    private float _turnSmoothVelocity;

    private bool _isGrounded;
    private float _jumpForceBase = 2.2f;
    private float _jumpForceAdd = 2.8f;
    //private float _jumpHeight = 3.0f;
    private float _gravityValue = -50f;

    Vector3 moveDire;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        _isGrounded = controller.isGrounded;
        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }
        //direction.z += _gravityValue;

        if (direction.magnitude >= 0.1f)
        {
            //Atan2 is a func that returns the angle b/t x axis and a vector that starts at the origin and terminating at x,y
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDire = moveDir;
            if (speed < speedMax)
                speed += speedAcc;
            else
                speed = speedMax;
            controller.Move(moveDir * speed * Time.deltaTime);
        }
        else
        {
            if (speed > 0)
            {
                if (_isGrounded)
                    speed -= speedGroundDacc;
                else
                    speed -= speedAirDacc;
            }
            else
                speed = 0;
            controller.Move(moveDire * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") )
        {
            if (_isGrounded)
            {
                Debug.Log("jump!"+ (_jumpForceBase * -_jumpForceBase * _gravityValue));
                _playerVelocity.y += Mathf.Sqrt(_jumpForceBase * -_jumpForceBase * _gravityValue);
            }
        }
        // if (Input.GetButton("Jump"))
        // {
        //     if (!_isGrounded)
        //     {
        //         Debug.Log("jumpControl!"+(_jumpForceAdd * -_jumpForceAdd * _gravityValue));
        //         _playerVelocity.y += Mathf.Sqrt(_jumpForceAdd * -_jumpForceAdd * _gravityValue) * Time.deltaTime;
        //     }
        //}

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        controller.Move(_playerVelocity * Time.deltaTime);
    }
}
