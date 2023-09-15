using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;

    public Transform Orientaion;

    float Hori;
    float Vert;

    Rigidbody rb;

    Vector3 moveDirection;



    //For Crouching
    public float crouchSpeed;
    public float crouchYscale;
    public float startYscale;
    bool crouching = false;
    




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();


        startYscale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

  

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        Hori = Input.GetAxisRaw("Horizontal");
        Vert = Input.GetAxisRaw("Vertical");


        //start to crouch 
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(crouching == false)
            {
                crouching = true;
            }
            if (crouching == true)
            {
                crouching = false;
            }
        }

        if (crouching == true)
        {
            //basically shrinks the capsule and then pushes the capsule down so it does not float 
            transform.localScale = new Vector3(transform.localScale.x, crouchYscale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            MoveSpeed = crouchSpeed;
        }

        if (crouching == false)
        {
            //basically shrinks the capsule and then pushes the capsule down so it does not float 
            transform.localScale = new Vector3(transform.localScale.x, startYscale, transform.localScale.z);
            MoveSpeed = MoveSpeed;
        }



    }

    private void MovePlayer()
    {
        moveDirection = Orientaion.forward * Vert + Orientaion.right * Hori;

        rb.AddForce(moveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);


    }
}
