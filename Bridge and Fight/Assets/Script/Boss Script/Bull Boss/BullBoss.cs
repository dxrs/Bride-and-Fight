using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullBoss : MonoBehaviour
{

    public static BullBoss bullBoss;

    public float bullBossHealth;

    public int id;
    public bool isSpikeSpawn;
    public bool isChassingPlayer;

    [SerializeField] GameObject objFollow;
    [SerializeField] GameObject spike;
    [SerializeField] GameObject body;
    [SerializeField] GameObject targetCircle;


    [SerializeField] bool isClockWiseRot;
    [SerializeField] bool isTargetToPlayer;

    [SerializeField] float delayTimeToChase;

    [SerializeField] float maxMoveSpeed;

    [SerializeField] float maxRotateSpeed;



    GameObject player1;
    GameObject player2;
    int indexPlayer;
    float movementSpeed = 1;
    float curRotSpeed = 200;
    float timer = 10;


    private void Awake()
    {
        if (bullBoss == null) { bullBoss = this; }
    }

    private void Start()
    {

        player1 = GameObject.FindGameObjectWithTag("Player 1");
        player2 = GameObject.FindGameObjectWithTag("Player 2");
        isSpikeSpawn = false;
        indexPlayer = Random.Range(0, 2);
        targetCircle.SetActive(false);
        if (indexPlayer == 0)
        {
           
            objFollow.transform.position = player1.transform.position;
            
        }
        if (indexPlayer == 1)
        {
            
            objFollow.transform.position = player2.transform.position;
           
        }
    }

    private void Update()
    {
        if (GameStarting.gameStarting.isGameStarted) 
        {
            if (isClockWiseRot) 
            {
                body.transform.Rotate(Vector3.back, curRotSpeed * Time.deltaTime);
                spike.transform.Rotate(Vector3.back, curRotSpeed * Time.deltaTime);
            }
            else 
            {
                body.transform.Rotate(-Vector3.back, curRotSpeed * Time.deltaTime);
                spike.transform.Rotate(-Vector3.back, curRotSpeed * Time.deltaTime);
            }

            
         
        }
       
        if (GameStarting.gameStarting.isGameStarted 
            && !GameOver.gameOver.isGameOver 
            && !GameFinish.gameFinish.isGameFinished
            && !GamePaused.gamePaused.isGamePaused)
        {

            bullBossFunction();
           
        }

        if(GameOver.gameOver.isGameOver || GameFinish.gameFinish.isGameFinished) 
        {
            Destroy(targetCircle);
        }
        

        

    }

    void bullBossFunction()
    {
        if (bullBossHealth <= 0) 
        {
            TotalCoin.totalCoin.curCoinGet = 100;
        }
        if (isTargetToPlayer)
        {
            targetCircle.SetActive(true);
            if (indexPlayer == 0)
            {
                targetCircle.transform.position = player1.transform.position;
            }
            if (indexPlayer == 1)
            {
                targetCircle.transform.position = player2.transform.position;
            }
        }


        if (!isChassingPlayer)
        {


           
            if (indexPlayer == 0)
            {
                objFollow.transform.position = player1.transform.position;

            }
            if (indexPlayer == 1)
            {
                objFollow.transform.position = player2.transform.position;

            }
            if (bullBossHealth >= 25) 
            {
                if (delayTimeToChase < timer)
                {
                    delayTimeToChase += Time.deltaTime;
                }
            }
            if (bullBossHealth < 25) 
            {
                delayTimeToChase += 2.5f * Time.deltaTime;
                transform.localScale = Vector2.MoveTowards(transform.localScale, new Vector2(2.5f, 2.5f), 1 * Time.deltaTime);
            }
          
        }
        else
        {


            if (movementSpeed < maxMoveSpeed)
            {
                movementSpeed += 5 * Time.deltaTime;
            }
            Mathf.Lerp(maxRotateSpeed, curRotSpeed, 4 * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, objFollow.transform.position, movementSpeed * Time.deltaTime);
        }
        if (delayTimeToChase >= timer)
        {
            isChassingPlayer = true;
            delayTimeToChase = 0;


        }



        if (transform.position == objFollow.transform.position)
        {
            isChassingPlayer = false;
            movementSpeed = 1;
        }
        if (delayTimeToChase >= 5 || bullBossHealth<25)
        {
            isSpikeSpawn = true;
        }
        if (delayTimeToChase >= 8)
        {
            isTargetToPlayer = true;
        }
    }


    public void triggerToObjFollow() 
    {
        targetCircle.SetActive(false);
        StartCoroutine(startToTargetPlayer());
        StartCoroutine(delaySpikeSpawn());
        isTargetToPlayer = false;
        if (!isClockWiseRot)
        {
            isClockWiseRot = true;
        }
        else
        {
            isClockWiseRot = false;
        }
    }

   
    IEnumerator startToTargetPlayer() 
    {
        yield return new WaitForSeconds(0.5f);
        indexPlayer = Random.Range(0, 2);
    }

    IEnumerator delaySpikeSpawn() 
    {
        if (bullBossHealth >= 45) 
        {
            yield return new WaitForSeconds(1.5f);
            isSpikeSpawn = false;
        }
       
    }
   
}
