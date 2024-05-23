using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Movement controller;

    public float runSpeed = 8f;

    float horizontalMove = 0f;
    float jump = 0;

    void Update ()
    {
        horizontalMove = Input.getAxisRaw("Horizontal") * runSpeed;

        if(Input.getButtonDown("Jump")){
            jump++;
        }
    }
    void FixedUpdate () {
//To move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, (jump == 0));
        jump--;
    }
}