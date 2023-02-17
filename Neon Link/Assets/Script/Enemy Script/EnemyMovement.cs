using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{




    GameObject player1;
    GameObject player2;
    GameObject player3;

    int indexPlayer;

    bool isEnemyDestroyed;

    Rigidbody2D rb;

    Vector2 movement;

    Vector2 dir;

    EnemyStatus enemyStatus;


   
    // Start is called before the first frame update
    void Start()
    {
        enemyStatus = GetComponent<EnemyStatus>();

        rb = GetComponent<Rigidbody2D>();


        

        player1 = GameObject.FindGameObjectWithTag("Player 1");
        player2 = GameObject.FindGameObjectWithTag("Player 2");
        player3 = GameObject.FindGameObjectWithTag("Player 3");


        indexPlayer = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameFinish.gameFinish.isGameFinished)
        {
            isEnemyDestroyed = true;

        }
        if (GameOver.gameOver.isGameOver) 
        {
            Destroy(gameObject, 30);
        }
        if (isEnemyDestroyed)
        {
            Destroy(gameObject);
        }

        if (UIStartGame.uIStartGame.levelType == "survive") 
        {
            if (player1 != null && player2 != null)
            {
                if (!ShadowAbility.shadowAbility.isShadowActivated && !GameOver.gameOver.isGameOver)
                {
                    if (indexPlayer == 0)
                    {
                        dir = player1.transform.position - transform.position;
                    }
                    if (indexPlayer == 1)
                    {
                        dir = player2.transform.position - transform.position;
                    }
                }


            }
            else
            {
                return;
            }
        }

        if (UIStartGame.uIStartGame.levelType == "protect") 
        {
            if (player3 != null) 
            {
                dir = player3.transform.position - transform.position;
            }
            else
            {
                return;
            }
        }
       
       

       


        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        dir.Normalize();
        movement = dir;
        
       
       
       
    }
    
    void FixedUpdate()
    {
        enemyMovement(movement);
    }

    void enemyMovement(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * enemyStatus.enemyMoveSpeed * Time.deltaTime));
    }

   
   

}
