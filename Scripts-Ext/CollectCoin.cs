using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public static int coins = 0;

    public void setCoins(int coins)
    {
        coins = coins;
    }
    public int getCoins()
    {
        return coins;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject colObj = col.gameObject;
        if (colObj.CompareTag("Player"))
        {
            this.GetComponent<SceneLoader>().OpenSceneCoin();

        }

    }   
}
