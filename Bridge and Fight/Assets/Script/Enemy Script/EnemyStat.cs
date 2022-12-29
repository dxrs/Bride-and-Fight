using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{

    public static EnemyStat enemyStat;

    public float speed;
    public float health;

    public int id;

    public AudioSource aSource;
    public AudioClip clipNya;

    public ParticleSystem enemyParticle;

    float slowSpeed = 2; // di bagi 2
    float curSpeed;

    private void Awake()
    {
        if (enemyStat == null) { enemyStat = this; }
    }
    private void Start()
    {
        curSpeed = speed;
    }
    void Update()
    {
        if(health <= 0)
        {
            enemyMati();
        }
    }

    public void enemyMati()
    {
        //audioManager.amanager.enemySound();
        Destroy(gameObject);
        Instantiate(enemyParticle, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player 1" || collision.gameObject.tag=="Player 2"
            ||collision.gameObject.tag=="Infinity Stone") 
        {
            Destroy(gameObject);
            Instantiate(enemyParticle, transform.position, Quaternion.identity);
        }
        if(collision.gameObject.tag=="Big Ball") 
        {
            StartCoroutine(getTriggerWithBigBall());
        }
        if(collision.gameObject.tag == "Player 1")
        {
            if (!GameOver.gameOver.isGameOver)
            {
                if (id == 1)
                {
                    Player1Health.player1Health.p1TriggerWithNormalEnemy();


                }
                if (id == 2)
                {
                    Player1Health.player1Health.p1TriggerWithMediumEnemy();
                   

                }



            }
            
           
        }
        if (collision.gameObject.tag == "Player 2")
        {
            if (!GameOver.gameOver.isGameOver)
            {
                if (id == 1)
                {
                    Player2Health.player2Health.p2TriggerWithNormalEnemy();


                }
                if (id == 2)
                {
                    Player2Health.player2Health.p2TriggerWithMediumEnemy();
                   

                }


            }
          
            
        }
    }

    IEnumerator getTriggerWithBigBall() 
    {
        speed = speed / slowSpeed;
        yield return new WaitForSeconds(6.5f);
        speed = curSpeed;
    }
}
