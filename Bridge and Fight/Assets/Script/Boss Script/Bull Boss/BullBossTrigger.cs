using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BullBossTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

       

        if (collision.gameObject.tag == "Player 1")
        {
            CameraShaker.Instance.ShakeOnce(4, 4, .1f, 1);
            if (!GameOver.gameOver.isGameOver)
            {
                Player1Health.player1Health.p1HitByBullBoss();



            }
        }
        if (collision.gameObject.tag == "Player 2")
        {
            CameraShaker.Instance.ShakeOnce(4, 4, .1f, 1);
            if (!GameOver.gameOver.isGameOver)
            {
                Player2Health.player2Health.p2HitByBullBoss();


            }


        }
    }
}
