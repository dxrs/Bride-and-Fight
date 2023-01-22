using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullBossBodyTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!BullBoss.bullBoss.isChassingPlayer) 
        {
            if (collision.gameObject.tag == "Bullet")
            {
                if (!UIPauseGame.uIPauseGame.isSceneEnded) 
                {
                    SoundEffect.soundEffect.audioSources[9].PlayOneShot(SoundEffect.soundEffect.audioClips[0]);
                }
               
                HitEffect.hitEffect.flashOut();
                

            }
        }

        if (collision.gameObject.tag == "Object Follow")
        {
            BullBoss.bullBoss.triggerToObjFollow();
        }

        

    }

   
}