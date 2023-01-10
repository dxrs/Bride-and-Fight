using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class UIInGame : MonoBehaviour
{
    public static UIInGame uIInGame;

    public bool isInGameUI;

    public float timerValue;

    [SerializeField] bool isTimerStart;

    [SerializeField] TextMeshProUGUI textTimer;
    [SerializeField] TextMeshProUGUI textCoin;

    

    TimeSpan timerCount;

    private void Awake()
    {
        uIInGame = this;
    }
    private void Start()
    {
        StartCoroutine(timerStarted());
    }
    private void Update()
    {
        if(GameStarting.gameStarting.isGameStarted && !GamePaused.gamePaused.isGamePaused
            &&!GameOver.gameOver.isGameOver && !GameFinish.gameFinish.isGameFinished) 
        {
            UIStartGame.uIStartGame.listUIObject[1].SetActive(true);
            
        }

        StartCoroutine(tes());

        textCoin.text= TotalCoin.totalCoin.curCoinGet.ToString();


        timerStart();
        timerEnd();
        
    }


    IEnumerator tes() 
    {
        if (GameOver.gameOver.isGameOver) 
        {
            Time.timeScale = 0.5f;
            yield return new WaitForSeconds(1);
            Time.timeScale = 1;
        }
        yield return null;
    }
    void timerStart() 
    {
        if (SceneManagerStatus.sceneManagerStatus.sceneStats == "Level") 
        {
            if(GameStarting.gameStarting.isGameStarted
                &&!GameOver.gameOver.isGameOver
                && !GameFinish.gameFinish.isGameFinished) 
            {
                isTimerStart = true;
            }
            if(GameOver.gameOver.isGameOver || GameFinish.gameFinish.isGameFinished) 
            {
                isTimerStart = false;
            }
        }
    }

    void timerEnd() 
    {
        if (timerValue <= 0) 
        {
            GameFinish.gameFinish.isGameFinished = true;
            timerValue = 0;
        }
    }

    IEnumerator timerStarted() 
    {
        while (true) 
        {
            if (isTimerStart) 
            {
                timerValue -= Time.deltaTime;
                timerCount = TimeSpan.FromSeconds(timerValue);
                string timer = timerCount.ToString("mm':'ss':'ff");
                textTimer.text = timer;
            }

            yield return null;
        }
    }

}
