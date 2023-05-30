using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public Joystick joystick;


    public float RunSpeed = 40f;

    private float HorizontalMove = 0f;
    private bool Jump = false;
    private bool Crouch = false;


    private void Update()
    {
        //HorizontalMove = joystick.Horizontal * RunSpeed;

        if (joystick.Horizontal >= .2f)
        {
            HorizontalMove = RunSpeed;
        } else if (joystick.Horizontal <= -.2f)
        {
            HorizontalMove = -RunSpeed;
        } else
        {
            HorizontalMove = 0f;
        }

        float VerticalMove = joystick.Vertical;

        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        if (VerticalMove >= .5f)
        {
            Jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (VerticalMove <= -.5f)
        {
            Crouch = true;
        } else 
        {
            Crouch = false;
        }
        
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool IsCrouching)
    {
        animator.SetBool("IsCrouching", IsCrouching);
    }

    private void FixedUpdate()
    {
        controller.Move(HorizontalMove * Time.fixedDeltaTime, Crouch, Jump);
        Jump = false;
    }
}
