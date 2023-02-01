using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BullBossSpike : MonoBehaviour
{
    PolygonCollider2D pc;


    private void Start()
    {
        transform.localScale = new Vector2(0, 0);
        pc = GetComponent<PolygonCollider2D>();
    }
    private void Update()
    {
        if (BullBoss.bullBoss.isSpikeSpawn) 
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, new Vector2(1, 1), 1 * Time.deltaTime);
        }
        else 
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, new Vector2(0, 0), 0.5f * Time.deltaTime);
        }

        if (transform.localScale.x < 1) 
        {
            pc.enabled = false;
        }
        if (transform.localScale.x == 1) 
        {
            pc.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player 1")
        {
            CameraShaker.Instance.ShakeOnce(4, 4, .1f, 1);
            if (!GameOver.gameOver.isGameOver)
            {
                Player1Health.player1Health.p1HitByBullBossSpike();



            }
        }
        if (collision.gameObject.tag == "Player 2")
        {
            CameraShaker.Instance.ShakeOnce(4, 4, .1f, 1);
            if (!GameOver.gameOver.isGameOver)
            {
                Player2Health.player2Health.p2HitByBullBossSpike();


            }


        }
    }


}
