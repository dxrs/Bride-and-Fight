using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerAbilityStatus : MonoBehaviour
{
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Normal Enemy"||collision.gameObject.tag=="Medium Enemy") 
        {
            /*
            if (Player1Health.player1Health.playerHealth < 50) 
            {
                Player1Health.player1Health.playerHealth++;
            }else if (Player1Health.player1Health.playerHealth >=50) { Player1Health.player1Health.playerHealth = 50; }
            if (Player2Health.player2Health.playerHealth < 50) 
            {
                Player2Health.player2Health.playerHealth++;
            }else if (Player2Health.player2Health.playerHealth >= 50) { Player2Health.player2Health.playerHealth = 50; }
            */
            gameObject.SetActive(false);
        }
    }
}
