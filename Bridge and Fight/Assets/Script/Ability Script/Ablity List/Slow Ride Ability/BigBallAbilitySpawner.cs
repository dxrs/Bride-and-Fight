using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BigBallAbilitySpawner : MonoBehaviour
{



    [SerializeField] GameObject player;
    [SerializeField] GameObject bigBall;

   
    [SerializeField] ParticleSystem slowRideParticleEffect;

    CircleCollider2D cc;

    private void Start()
    {
        cc = GetComponent<CircleCollider2D>();
    }


    private void Update()
    {
       
        if (!GameOver.gameOver.isGameOver
             && GameStarting.gameStarting.isGameStarted
             && !GamePaused.gamePaused.isGamePaused
             && !GameFinish.gameFinish.isGameFinished
             && UIStartGame.uIStartGame.abilitySelectedValue == 3) 
        {
           
            if (player != null)
            {
                cc.enabled = true;

                transform.localPosition = player.transform.position;
            }
        }
       

        if(GameFinish.gameFinish.isGameFinished || GameOver.gameOver.isGameOver) 
        {
            Destroy(gameObject);
        }
    
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Normal Enemy" || collision.gameObject.tag == "Medium Enemy")
        {
            Instantiate(bigBall, transform.localPosition, Quaternion.identity);
            Instantiate(slowRideParticleEffect, transform.localPosition, Quaternion.identity);
         
        }
    }
}
