using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Health : MonoBehaviour
{
    public static Player2Health player2Health;

    public float playerHealth;

    private void Awake()
    {
        if (player2Health == null) { player2Health = this; }
    }
    private void Update()
    {
        if (playerHealth <= 0)
        {
            TotalCoin.totalCoin.curCoinGet = 0;
            GameOver.gameOver.isGameOver = true;
        }
       
    }
    public void p2TriggerWithNormalEnemy() 
    {
        playerHealth -= 10;
    }
    public void p2TriggerWithMediumEnemy() 
    {
        playerHealth -= 20;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player 1") 
        {
            Player1Health.player1Health.p1SuicideKill();
        }
    }
}