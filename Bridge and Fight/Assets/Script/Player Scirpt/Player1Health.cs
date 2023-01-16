using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Health : MonoBehaviour
{
    public static Player1Health player1Health;

    public float playerHealth;

    [SerializeField] Image player_1_HealthBar;

    float curHealthBarValue;
    float maxHealthBarValue = 50;

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

        curHealthBarValue = playerHealth;
        player_1_HealthBar.fillAmount = curHealthBarValue / maxHealthBarValue;
       
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall") 
        {
            playerHealth -= 200;
        }
        
    }

    public void p1TriggerWithNormalEnemy() 
    {
        playerHealth -= 3;
    }
    public void p1TriggerWithMediumEnemy() 
    {
        playerHealth -= 6;
    }
    public void p1SuicideKill() 
    {
        playerHealth -= 100;
    }

    public void p1HitByBullBoss() 
    {
        playerHealth -= 8;
    }



   
}
