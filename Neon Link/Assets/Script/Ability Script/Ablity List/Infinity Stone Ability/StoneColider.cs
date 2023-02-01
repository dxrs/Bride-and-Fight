using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneColider : MonoBehaviour
{
    public static StoneColider stoneColider;

    public int curStoneValue;
    public int id;

    public GameObject[] stone;

    [SerializeField] float delayTime;
    

    [SerializeField] float stoneTimerSpawn;
   

    int curLevel;
    CircleCollider2D cc;

    private void Awake()
    {
        if (stoneColider == null) { stoneColider = this; }
        
    }

    private void Start()
    {
        curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[3]);
        cc = GetComponent<CircleCollider2D>();
        if (curLevel == 1)
        {
            stoneTimerSpawn = 12;
            curStoneValue = 2;

        }
        if (curLevel == 2)
        {
            stoneTimerSpawn = 21.5f;
            curStoneValue = 4;
        }
        if (curLevel == 3)
        {
            stoneTimerSpawn = 30.5f;
            curStoneValue = 8;
        }

    }

    private void Update()
    {

        abilityStoneActivated();

    }

    void abilityStoneActivated() 
    {
        if(UIStartGame.uIStartGame.abilitySelectedValue == 1 && GameStarting.gameStarting.isGameStarted) 
        {
            totalStone();
            if (curStoneValue > InfinityStoneAbility.infinityStone.maxStoneValue) { curStoneValue = InfinityStoneAbility.infinityStone.maxStoneValue; }
            if (curStoneValue <= InfinityStoneAbility.infinityStone.maxStoneValue)
            {
                stoneTimerSpawn += 0.35f* Time.deltaTime;
                if (stoneTimerSpawn >= delayTime)
                {
                    stoneTimerSpawn = 0f;
                    curStoneValue++;
                }
                /*
                if (id == 1)
                {
                    
                }
                if (id == 2)
                {
                    timerCountp2 += Time.deltaTime;
                    if (timerCountp2 >= delayTime)
                    {
                        timerCountp2 = 0f;
                        curStoneValue++;
                    }
                }
                */
            }
            
            if (curStoneValue <= 0)
            {
                cc.enabled = false;
            }
            else if (curStoneValue > 0)
            {
                cc.enabled = true;
            }
        }
    }
    void totalStone() 
    {
       

        for (int i = 0; i < stone.Length; i++)
        {
            if (curStoneValue <= i)
            {
                stone[i].SetActive(false);
            }
            else
            {
                stone[i].SetActive(true);
            }
        }

        //upgrade stone ability
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Normal Enemy") 
        {
            stoneTimerSpawn = 0f;
            //timerCountp2 = 0f;
            if (curStoneValue > 0) 
            {
                curStoneValue--;
            }
            if (id == 1)
            {
               
                if (curStoneValue < 1)
                {

                    Player1Health.player1Health.p1TriggerWithNormalEnemy();

                }
            }
            if (id == 2)
            {
                if (curStoneValue < 1)
                {

                    Player2Health.player2Health.p2TriggerWithNormalEnemy();

                }
               
            }

        }
        if(collision.gameObject.tag=="Medium Enemy") 
        {
            stoneTimerSpawn = 0f;
            //timerCountp2 = 0f;
            if (curStoneValue > 0)
            {
                curStoneValue-=2;
            }
            if (id == 1)
            {
                if (curStoneValue < 1)
                {

                    Player1Health.player1Health.p1TriggerWithMediumEnemy();

                }
               
            }
            if (id == 2)
            {
                if (curStoneValue < 1)
                {

                    Player2Health.player2Health.p2TriggerWithMediumEnemy();

                }
              
            }
            if (curStoneValue < 1)
            {
               


            }
        }

       
    }
    

}
