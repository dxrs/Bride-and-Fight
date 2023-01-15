using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BigBallAbilitySpawner : MonoBehaviour
{
    public static BigBallAbilitySpawner bigBallAbilitySpawner;


    [SerializeField] GameObject player;
    [SerializeField] GameObject bigBall;

    [SerializeField] ParticleSystem slowRideParticleEffect;





    private void Awake()
    {
        bigBallAbilitySpawner = this;
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
                transform.localPosition = player.transform.position;
            }
        }
        else 
        {
            gameObject.SetActive(false);
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
