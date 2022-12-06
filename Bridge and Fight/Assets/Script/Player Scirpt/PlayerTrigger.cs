using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public static PlayerTrigger playerTrigger;

    public bool isP1_ColtoCamEdge, isP2_ColtoCamEdge;

    public ParticleSystem playerParticle;

    public float curSpeed = 3;
    float slowSpeed=1;

    [SerializeField] int numbPlayer;
    private void Awake()
    {
        if (playerTrigger == null) { playerTrigger = this; }
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
        if (collision.gameObject.tag == "obstacle") 
        {
            if (numbPlayer == 1) 
            {
                PlayerMovement.playerMovement.movementSpeedP1 = slowSpeed;
            }
            if (numbPlayer == 2) 
            {
                PlayerMovement.playerMovement.movementSpeedP2 = slowSpeed;
            }
        }
        if (collision.gameObject.tag == "Normal Enemy")
        {

            PlayerDestroy.playerDestroy.isGameOver = true;
            Instantiate(playerParticle, transform.position, Quaternion.identity);
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
        if (collision.gameObject.tag == "obstacle")
        {
            if (numbPlayer == 1)
            {
                PlayerMovement.playerMovement.movementSpeedP1 = curSpeed;
            }
            if (numbPlayer == 2)
            {
                PlayerMovement.playerMovement.movementSpeedP2 = curSpeed;
            }
        }
    }
}
