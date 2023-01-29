using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BullBossBodyTrigger : MonoBehaviour
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
        if (!BullBoss.bullBoss.isChassingPlayer) 
        {
            if (collision.gameObject.tag == "Bullet")
            {
                if (!UIPauseGame.uIPauseGame.isSceneEnded) 
                {
                    SoundEffect.soundEffect.audioSources[9].PlayOneShot(SoundEffect.soundEffect.audioClips[0]);
                }
               
                HitEffect.hitEffect.flashOut();
                if (!BullBoss.bullBoss.isChassingPlayer) 
                {
                    BullBoss.bullBoss.bullBossHealth -= 0.5f;
                }
                

            }
        }

        if (collision.gameObject.tag == "Object Follow")
        {
            BullBoss.bullBoss.triggerToObjFollow();
        }

        

    }

   
}
