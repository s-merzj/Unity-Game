using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.ShaderGraph.Internal;
 
public class HealthDisplay : MonoBehaviour
{
    public Texture[] m_Texture;
    public GameObject[] Hearts;
 
    public void UpdateHearts(int health){
 
        for (int i = 0; i < this.Hearts.Length; i++)
        {
            if (health >= 2)
            {
                this.Hearts[i].GetComponent<RawImage>().texture = m_Texture[2]; // FULL
            }
            else if (health == 1)
            {
                this.Hearts[i].GetComponent<RawImage>().texture = m_Texture[1]; // HALF
            }
            else
            {
                this.Hearts[i].GetComponent<RawImage>().texture = m_Texture[0]; // EMPTY
            }
            health = (health-2 > 0) ? health-2 : 0;
        }
    }
    void Start(){
       
    }
    void Update()
    {
 
    }
 
}