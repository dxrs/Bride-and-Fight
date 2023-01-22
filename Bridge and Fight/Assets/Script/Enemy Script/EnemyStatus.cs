using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyStatus : MonoBehaviour
{

    public static EnemyStatus enemyStatus;

    public float enemyMoveSpeed;
    public float enemyHealth;

    public int id;
    public int randomTarget;

    [SerializeField] ParticleSystem enemyParticle;

    [SerializeField] GameObject friendlyBot;

    [SerializeField] float slowedDownTime;


    float slowSpeed; // di bagi 2
    float curSpeed;

    int curSlowRideLevel;

    public bool demaged = false;

    bool enemyIsDestroyed;
    bool isAddingPlayerHealth;

    private void Awake()
    {
        if (enemyStatus == null) { enemyStatus = this; }
    }
    private void Start()
    {
        curSpeed = enemyMoveSpeed;
        curSlowRideLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[11]);
        if (curSlowRideLevel == 1) 
        {
            slowedDownTime = 4;
            slowSpeed = 1.5f;
        }
        if(curSlowRideLevel == 2)
        {
            slowSpeed = 2;
        }
        if (curSlowRideLevel == 3)
        {
            slowedDownTime = 6.5f;
            slowSpeed = 2;
        }
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
        if (UIPauseGame.uIPauseGame.isSceneEnded) { Destroy(gameObject); }

        if (curSlowRideLevel >= 2 && !GameOver.gameOver.isGameOver && !GameFinish.gameFinish.isGameFinished) 
        {
            if (isAddingPlayerHealth)
            {
                Player1Health.player1Health.addP1Health();
                Player2Health.player2Health.addP2Health();
            }
        }
       
    }

    public void enemyDestroy()
    {
        enemyIsDestroyed = true;
        Destroy(gameObject);
        Instantiate(enemyParticle, transform.position, Quaternion.identity);
    }
    private void OnDestroy()
    {
        if (enemyIsDestroyed && !GameFinish.gameFinish.isGameFinished && !GameOver.gameOver.isGameOver && !UIPauseGame.uIPauseGame.isSceneEnded) 
        {
            CameraShaker.Instance.ShakeOnce(4, 4, .1f, 1);
            SoundEffect.soundEffect.audioSources[2].Play();
        }

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player 1" || collision.gameObject.tag=="Player 2"
            ||collision.gameObject.tag=="Infinity Stone"
            ||collision.gameObject.tag=="Friendly Bot"
            ||collision.gameObject.tag=="Diamond") 
        {
            CameraShaker.Instance.ShakeOnce(4, 4, .1f, 1);
            SoundEffect.soundEffect.audioSources[2].Play();
            Destroy(gameObject);
            Instantiate(enemyParticle, transform.position, Quaternion.identity);
        }
        if(collision.gameObject.tag=="Big Ball") 
        {
            StartCoroutine(getTriggerWithBigBall());
            StartCoroutine(addPlayerHealth());
        }
        if (collision.gameObject.tag == "Bullet") 
        {
            if (!UIPauseGame.uIPauseGame.isSceneEnded) 
            {
                if (id == 2) 
                {
                    SoundEffect.soundEffect.audioSources[9].PlayOneShot(SoundEffect.soundEffect.audioClips[0]);
                }
             
            }
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
        if (collision.gameObject.tag == "Friendly Bot")
        {
            if (PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[5]) >= 2) 
            {
                if (id == 1)
                {
                    TotalCoin.totalCoin.curCoinGet += 2;
                }
                if (id == 2)
                {
                    TotalCoin.totalCoin.curCoinGet += 4;
                }
            }
          
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
        yield return new WaitForSeconds(slowedDownTime);
        enemyMoveSpeed = curSpeed;
    }

    IEnumerator addPlayerHealth() 
    {
        isAddingPlayerHealth = true;
        yield return new WaitForSeconds(2);
        isAddingPlayerHealth =false;
    }
}
