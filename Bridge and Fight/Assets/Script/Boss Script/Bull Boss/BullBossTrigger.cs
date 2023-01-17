using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullBossTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag=="Object Follow") 
        {
            BullBoss.bullBoss.triggerToObjFollow();
        }

        if (collision.gameObject.tag == "Player 1")
        {
            if (!GameOver.gameOver.isGameOver)
            {
                Player1Health.player1Health.p1HitByBullBoss();



            }
        }
        if (collision.gameObject.tag == "Player 2")
        {
            if (!GameOver.gameOver.isGameOver)
            {
                Player2Health.player2Health.p2HitByBullBoss();


            }


        }
    }
}
