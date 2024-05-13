using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damage = 1;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //GameObject.FindGameObjectsWithTag("Hearts") hint use the aray list thingi
        GameObject go = col.gameObject;
        if (go.CompareTag("Player"))
        {
            // GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerHealth playerHealth = go.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
    }
}