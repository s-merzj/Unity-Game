using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] bool destroyOnContact = false;
    [SerializeField] public bool spawnFlipped = false;
    [SerializeField] bool flipOnColliderEdge = true;

    Rigidbody2D myRigidBody;
    Collider2D myBoxCollider;
    public int damage = 6;
    public bool moveRight = true;
    private float spawnTime;
    public bool isProj = false;
    public float projectileDist = 99999;
    private float spawnPos = 0;
    

    void Start() {
        if(!moveRight){
            this.gameObject.transform.Rotate(0, 180, 0, Space.World);
        }
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<Collider2D>();  
        spawnPos = this.gameObject.transform.position.x;
        if (spawnFlipped) {this.moveRight = !this.moveRight;} 
        this.spawnTime = Time.time;
    }

    void Update() {
       if(IsFacingRight()) {
            //move right hehehehe
            myRigidBody.velocity = new Vector2(moveSpeed,0f);
       } else {
            myRigidBody.velocity = new Vector2(-(moveSpeed),0f);
       }
       if(Mathf.Abs(this.gameObject.transform.position.x - spawnPos) > projectileDist && isProj){
        Destroy(this.gameObject);
       }
    }

    private bool IsFacingRight() {
        return ((transform.localScale.x > Mathf.Epsilon) && moveRight);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (this.flipOnColliderEdge) {
            if (collision.gameObject.CompareTag("Ground") && moveRight) {
                transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)*2), transform.localScale.y);
                moveRight = (moveRight!);
            } else {
                transform.localScale = new Vector2((Mathf.Sign(myRigidBody.velocity.x)*2), transform.localScale.y);
                moveRight = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        
        GameObject go = col.gameObject;
        if (go.CompareTag("Player")) {
            PlayerHealth playerHealth = go.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }

        this.ContactEvent(col);
    }

    public bool ContactEvent(Collision2D col) {
        if (this.destroyOnContact && col.gameObject.tag != "Spawner" && col.gameObject.tag != "Enemy") {
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }
}
