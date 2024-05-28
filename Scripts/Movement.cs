using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 14f;
    private bool isRight = true;
    public bool jump = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
//    updates once per frame to allow the character to remain horizontal
    void Update(){
        horizontal = Input.GetAxisRaw("Horizontal");
//Jump detection
        if(Input.GetButtonDown("Jump")){
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jump = false;
        }

         Flip(); 
    }
    void FixedUpdate () {
//To move the character
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); 
    }

    void onTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Ground")){
            jump = true; 
        }
    }
    private void Flip(){
        if(isRight && horizontal < 0f || !isRight && horizontal > 0f){
            isRight = !isRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}