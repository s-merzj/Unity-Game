using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    //fuckitweball
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 17f;
    private bool isFacingRight = true;
    
    //next few are for double jump
    private bool doubleJump;
    
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(IsGrounded() && !Input.GetButton("Jump")){
            doubleJump = false;
        }
        if(Input.GetButtonDown("Jump") && IsGrounded || doubleJump ()){
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            doubleJump = !doubleJump;
        }
        if(Input.GetButtonUp("Jump") && rb.velocity.y>0f()){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            
        }
        Flip();
    }
    private void FixedUpdate(){
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool IsGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);


    }
    private void Flip(){
        if(isFacingRight&&horizontal<0f||!isFacingRight&&horizontal>0f){
            isfacingright = !isfacingright;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;   
        }
    }
}
