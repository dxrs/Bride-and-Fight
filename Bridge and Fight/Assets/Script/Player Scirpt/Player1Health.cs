using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Health : MonoBehaviour
{
    public static Player1Health player1Health;

    public float playerHealth;

    private void Awake()
    {
        if (player1Health == null) { player1Health = this; }
    }
    private void Update()
    {
        if (playerHealth <= 0)
        {
            TotalCoin.totalCoin.curCoinGet = 0;
            GameOver.gameOver.isGameOver = true;
        }
       
        
    }

    public void p1TriggerWithNormalEnemy() 
    {
        playerHealth -= 10;
    }
    public void p1TriggerWithMediumEnemy() 
    {
        playerHealth -= 20;
    }
    public void p1SuicideKill() 
    {
        playerHealth -= 100;
    }



   
}
