using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject targetPlayer;

    private void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player 2");
    }
    private void Update()
    {
        if (!GameOver.gameOver.isGameOver && !GameFinish.gameFinish.isGameFinished) 
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.transform.position, 10 * Time.deltaTime);
            if(Vector2.Distance(transform.position, targetPlayer.transform.position) <= 0.1)
            {
                Destroy(this.gameObject);
            }
        }
       
        if(GameOver.gameOver.isGameOver || GameFinish.gameFinish.isGameFinished 
            || ShadowAbility.shadowAbility.isShadowActivated 
            )
        {
            Destroy(this.gameObject);
        }

        if (GamePaused.gamePaused.isGamePaused) 
        {
            gameObject.SetActive(false);
        }
        else { gameObject.SetActive(true); }

        if (!BulletConnect.bulletConnect.isConnected ) 
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(0, 0), 15 * Time.deltaTime);

        }
       
       
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle") 
        {
            Destroy(gameObject);
        }
    }
}
