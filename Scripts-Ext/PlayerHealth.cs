using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class PlayerHealth : MonoBehaviour
{
    public static int maxHealth = 6;
    public int health = maxHealth;
    public int numberOfNoHeart = 0;
    public bool HalfHeart = false;

    public void TakeDamage(int damage){

        GameObject go = GameObject.FindGameObjectWithTag("Hearts");
        HealthDisplay hd = go.GetComponent<HealthDisplay>();
        health -= damage;

        hd.UpdateHearts(health);

        if (health <= 0){
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            SceneManager.LoadScene("Level -3");
        }
    }
    public void Heal(int amount){
        if(health + amount > maxHealth){
            health = maxHealth;
        }
        else{
            health += amount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
