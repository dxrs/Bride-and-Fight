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

    [SerializeField]
    GameObject healParticle;

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
        if(playerHealth >= 30)
        {
            healParticle.SetActive(false);
        }
        curHealthBarValue = playerHealth;
        player_2_HealthBar.fillAmount = curHealthBarValue / maxHealthBarValue;

    }
    public void p2TriggerWithNormalEnemy() 
    {
        playerHealth -= 4;
    }
    public void p2TriggerWithMediumEnemy() 
    {
        playerHealth -= 7;
    }

    public void p2HitByBullBoss()
    {
        playerHealth -= 7.5f;
    }
    public void p2HitByBullBossSpike()
    {
        playerHealth -= 2;
    }

    public void addP2Health()
    {
        if (playerHealth == Mathf.Clamp(playerHealth, 1, 30))
        {
            playerHealth += 0.3f * Time.deltaTime;
            healParticle.SetActive(true);
        }
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bull Boss")
        {
            playerHealth -= 2 * Time.deltaTime;
        }
    }


}
