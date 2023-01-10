using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Health : MonoBehaviour
{
    public static Player2Health player2Health;

    public float playerHealth;

    [SerializeField] Image player_2_HealthBar;

    float curHealthBarValue;
    float maxHealthBarValue = 50;

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
        curHealthBarValue = playerHealth;
        player_2_HealthBar.fillAmount = curHealthBarValue / maxHealthBarValue;

    }
    public void p2TriggerWithNormalEnemy() 
    {
        playerHealth -= 5;
    }
    public void p2TriggerWithMediumEnemy() 
    {
        playerHealth -= 10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player 1") 
        {
            Player1Health.player1Health.p1SuicideKill();
        }
        if (collision.gameObject.tag == "Wall")
        {
            playerHealth -= 200;
            
        }

    }
}
