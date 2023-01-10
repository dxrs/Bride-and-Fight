using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{

    public static EnemyStatus enemyStatus;

    public float enemyMoveSpeed;
    public float enemyHealth;

    public int id;
    public int randomTarget;

    [SerializeField] ParticleSystem enemyParticle;

    [SerializeField] GameObject friendlyBot;


    float slowSpeed = 2; // di bagi 2
    float curSpeed;

    public bool demaged = false;

   

    private void Awake()
    {
        if (enemyStatus == null) { enemyStatus = this; }
    }
    private void Start()
    {
        curSpeed = enemyMoveSpeed;
    }
    void Update()
    {
        if(enemyHealth <= 0)
        {
            enemyDestroy();
        }
        
        if(demaged)
        {
            HitEffect.hitEffect.flashOut();
        }
    }

    public void enemyDestroy()
    {
       
        Destroy(gameObject);
        Instantiate(enemyParticle, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player 1" || collision.gameObject.tag=="Player 2"
            ||collision.gameObject.tag=="Infinity Stone"
            ||collision.gameObject.tag=="Friendly Bot") 
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

        if (collision.gameObject.tag == "Diamond") 
        {
            Destroy(gameObject);
            Instantiate(friendlyBot, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            HitEffect hitEffect = gameObject.GetComponent<HitEffect>();
            if (hitEffect != null && !ShadowAbility.shadowAbility.isShadowActivated) 
            {
                hitEffect.flashOut();
            }
          
           
        }

       
        
    }

    IEnumerator getTriggerWithBigBall() 
    {
        enemyMoveSpeed = enemyMoveSpeed / slowSpeed;
        yield return new WaitForSeconds(6.5f);
        enemyMoveSpeed = curSpeed;
    }
}
