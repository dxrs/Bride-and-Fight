using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public static PlayerTrigger playerTrigger;

    public bool isP1_ColtoCamEdge, isP2_ColtoCamEdge;
    public bool colObstacle_p1, colObstacle_p2;

    public ParticleSystem playerParticle;

    public float playerHealth;
  

    [SerializeField] int numbPlayer;
    private void Awake()
    {
        if (playerTrigger == null) { playerTrigger = this; }
    }
    private void Update()
    {
        if (playerHealth <= 0) 
        {
            GameOver.gameOver.isGameOver=true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Camera Edge") 
        {
            if (numbPlayer == 1) 
            {
                isP1_ColtoCamEdge = true;
            }
            if (numbPlayer == 2) 
            {
                isP2_ColtoCamEdge = true;
            }
        }
        if(collision.gameObject.tag=="Normal Enemy"||collision.gameObject.tag=="Medium Enemy") 
        {
            if (TotalCoin.totalCoin.curCoinGet > 0) 
            {
                TotalCoin.totalCoin.curCoinGet -= 5;
            }
        }
        if (collision.gameObject.tag == "Normal Enemy")
        {

            playerHealth -= 10;
            
        }
        if(collision.gameObject.tag == "Medium Enemy") 
        {
            playerHealth -= 20;
         
        }
        if(collision.gameObject.tag=="Player 1") 
        {
            playerHealth -= 100;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Camera Edge")
        {
            if (numbPlayer == 1)
            {
                isP1_ColtoCamEdge = false;
            }
            if (numbPlayer == 2)
            {
                isP2_ColtoCamEdge = false;
            }
        }
        
    }
}
