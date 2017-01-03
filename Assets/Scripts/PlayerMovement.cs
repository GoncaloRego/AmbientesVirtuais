﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private Transform playerTransform;
    Animator animation;
    public float jumpSpeed;
    public float speed;
    public float gravity;
    bool isMoving;
    bool isRunning;

	void Start ()
    {
        animation = GetComponent<Animator>();

        playerRigidBody = GetComponent<Rigidbody>();
        playerTransform = transform;

        isMoving = false;
        isRunning = false;
	}
	
    void MovePlayer()
    {
        float moveHorizontal, moveVertical, jump;
        Vector3 movement = Vector3.zero;

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");

        movement = new Vector3(moveHorizontal, jump * jumpSpeed, moveVertical);
        playerTransform.position += movement * Time.deltaTime * speed;

        RaycastHit floorHit;
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(camRay, out floorHit, 100.0f, LayerMask.GetMask("Box001")))
        {
            Vector3 playerToMouse = floorHit.point - playerTransform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidBody.MoveRotation(newRotation);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }

        if (movement != Vector3.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    void Run()
    {
        isMoving = false;

        float moveHorizontal, moveVertical, jump, runSpeed = 3f;
        Vector3 movement;

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");

        movement = new Vector3(moveHorizontal, jump * jumpSpeed, moveVertical);
        playerTransform.position += movement * runSpeed * Time.deltaTime;

        isRunning = true;
    }

    void animationControl()
    {

        if (isMoving == true)
        {
            animation.SetBool("andar", true);
        }

        else
        {
            animation.SetBool("andar", false);
        }

        if(isRunning == true)
        {
            animation.SetBool("correr", true);
        }

        else
        {
            animation.SetBool("correr", false);
        }
        /*
        animation.ResetTrigger("Idle");
        animation.ResetTrigger("Walk");
        animation.ResetTrigger("Run");
        if (isMoving == false && isRunning == false)
        {
            animation.SetTrigger("Idle");
            //animation.Play("Idle");
        }

        else if(isMoving == true)
        {
            animation.SetTrigger("Walk");
            //animation.Play("Walk");
        }

        else if(isRunning == true)
        {
            animation.SetTrigger("Run");
            //animation.Play("Run");
        }
        */
    }
     //hjsgdfkas
	void Update ()
    {
        MovePlayer();
        animationControl();
	}
}
