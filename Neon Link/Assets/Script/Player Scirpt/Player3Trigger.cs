using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Trigger : MonoBehaviour
{
    [SerializeField] Transform player3Body;
    [SerializeField] ParticleSystem player3Particle;


   

    private void Update()
    {
        if (player3Body.localScale.x <= 0) 
        {
            
            GameOver.gameOver.isGameOver = true;
        }
        if (GameOver.gameOver.isGameOver) 
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (GameOver.gameOver.isGameOver) 
        {
            Instantiate(player3Particle, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") 
        {
            if (player3Body.localScale.x < 1) 
            {
                player3Body.localScale += new Vector3(0.001f, 0.001f, 0.001f);
            }
        }
        if(collision.gameObject.tag=="Player 1" || collision.gameObject.tag=="Player 2") 

        {
            player3Body.localScale = new Vector2(0, 0);
            GameOver.gameOver.isGameOver = true;
            Instantiate(player3Particle, transform.position, Quaternion.identity);
        }

        if(collision.gameObject.tag=="Normal Enemy") 
        {
            Instantiate(player3Particle, transform.position, Quaternion.identity);
            player3Body.localScale -= new Vector3(0.25f, 0.25f, 0.1f);
        }
    }
}
