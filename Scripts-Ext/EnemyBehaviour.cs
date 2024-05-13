using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D myRigidBody;
    BoxCollider2D myBoxCollider;
    public int damage = 6;
    public bool moveRight = true;
    void Start(){
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();   
    }
    void Update(){
       if(IsFacingRight()) {
            //move right hehehehe
            myRigidBody.velocity = new Vector2(moveSpeed,0f);
       } 
       else 
       {
            myRigidBody.velocity = new Vector2(-(moveSpeed),0f);
       }
    }
    private bool IsFacingRight(){
        return (transform.localScale.x > Mathf.Epsilon) && moveRight;
        
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Ground")){
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)*2), transform.localScale.y);
            moveRight = (moveRight!);
        }
    }
    void OnCollisionEnter2D(Collision2D col){
        
        GameObject go = col.gameObject;
        if (go.CompareTag("Player"))
        {
            PlayerHealth playerHealth = go.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }

    }
}