using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullBoss : MonoBehaviour
{
    [SerializeField] GameObject[] player;
    [SerializeField] GameObject objFollow;

    [SerializeField] bool isChassingPlayer;

    [SerializeField] float delayTimeToChase;

    [SerializeField] float maxMoveSpeed;

    [SerializeField] float maxRotateSpeed;

    int indexPlayer;
    float movementSpeed = 1;
    float curRotSpeed = 200;
    float timer;

    private void Start()
    {
        indexPlayer = Random.Range(0, 2);
        
        if (indexPlayer == 0)
        {
           
            objFollow.transform.position = player[0].transform.position;
            
        }
        if (indexPlayer == 1)
        {
            
            objFollow.transform.position = player[1].transform.position;
           
        }
    }

    private void Update()
    {
       
        if (GameStarting.gameStarting.isGameStarted 
            && !GameOver.gameOver.isGameOver 
            && !GameFinish.gameFinish.isGameFinished
            && !GamePaused.gamePaused.isGamePaused)
        {


            transform.Rotate(-Vector3.back,  curRotSpeed * Time.deltaTime);
            if (!isChassingPlayer)
            {
                Mathf.Lerp(curRotSpeed, maxRotateSpeed, 4 * Time.deltaTime);
                if (indexPlayer == 0)
                {
                    objFollow.transform.position = player[0].transform.position;
                   
                }
                if (indexPlayer == 1)
                {
                    objFollow.transform.position = player[1].transform.position;
                    
                }
                if (timer < delayTimeToChase) 
                {
                    timer += Time.deltaTime;
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
           
           
        }
        if (timer >= delayTimeToChase) 
        {
            isChassingPlayer = true;
            timer = 0;
            
        }

        if (transform.position == objFollow.transform.position) 
        {
            isChassingPlayer = false;
            movementSpeed = 1;
        }

        

    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Object Follow") 
        {
            
            indexPlayer = Random.Range(0, 2);
            print("kena");
        }
    }
    IEnumerator waitToChassing() 
    {
        yield return new WaitForSeconds(delayTimeToChase);
        isChassingPlayer = true;
    }
}
