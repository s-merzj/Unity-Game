using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D myRigidBody;
    BoxCollider2D myBoxCollider;
    void Start(){
        myRigidBody = GetComponent<Rigidbody2D>;
        myBoxCollider = GetComponent<BoxCollider2D>;   
    }
    void Update(){
       if(IsFacingRight()) {
            //move right hehehehe
            myRigidBody.velocity = new Vector2(moveSpeed,1f);
       } else {
            myRigidBody.velocity = new Vector2(-(moveSpeed),1f);
       }
    }
    private bool IsFacingRight(){
        return transform.localscale.x > Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D collision){
        transform.localscale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), transform.localscale.y)
    }
}