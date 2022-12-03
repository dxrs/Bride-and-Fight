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
        if (!PlayerDestroy.playerDestroy.isGameOver && !GameFinish.gameFinish.isGameFinished
            &&!PlayerInvisible.playerInvisible.isInvisible) 
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.transform.position, 10 * Time.deltaTime);
            if(Vector2.Distance(transform.position, targetPlayer.transform.position) <= 0.1)
            {
                Destroy(this.gameObject);
            }
        }
       
        if(PlayerDestroy.playerDestroy.isGameOver || GameFinish.gameFinish.isGameFinished
            || PlayerInvisible.playerInvisible.isInvisible)
        {
            Destroy(this.gameObject);
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
