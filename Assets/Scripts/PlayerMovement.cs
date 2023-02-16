using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float RunSpeed = 40f;

    private float HorizontalMove = 0f;
    private bool Jump = false;
    private bool Crouch = false;


    private void Update()
    {
       HorizontalMove = Input.GetAxisRaw("Horizontal") * RunSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
        }

        if (Input.GetButtonDown("Crouch")){
            Crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            Crouch = false;
        }
        
    }

    private void FixedUpdate()
    {
        controller.Move(HorizontalMove * Time.fixedDeltaTime, Crouch, Jump);
        Jump = false;
    }
}
