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
    public bool imageCoinAnimated;

    public float timerValue;

    public GameObject coinImageObj;

    [SerializeField] bool isTimerStart;

    [SerializeField] TextMeshProUGUI textTimer;
    [SerializeField] TextMeshProUGUI textCoin;
    [SerializeField] TextMeshProUGUI textAlmostDone;

    [SerializeField] Image imageCoin;

    

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

        StartCoroutine(slowMotion());
       
        if (SceneManagerStatus.sceneManagerStatus.sceneStats == "Level") 
        {
            textCoin.text = TotalCoin.totalCoin.curCoinGet.ToString();

            if(!GameOver.gameOver.isGameOver && !GameFinish.gameFinish.isGameFinished) 
            {
                if (timerValue < 30)
                {
                    textAlmostDone.enabled = true;
                    if (Music.music.id == "Level")
                    {
                        Music.music.audioSource.pitch = Mathf.Lerp(Music.music.audioSource.pitch, 1.1f, 1 * Time.deltaTime);

                    }
                  
                }
            }
            


            timerStart();
            timerEnd();
        }
        else 
        {
            textCoin.enabled = false;
            textTimer.enabled = false;
            imageCoin.enabled = false;
        }

        if (imageCoinAnimated) 
        {
            coinImageObj.transform.localScale = Vector2.MoveTowards(coinImageObj.transform.localScale, new Vector2(1f, 1f), 1 * Time.deltaTime);
        }
        else 
        {
            coinImageObj.transform.localScale = Vector2.MoveTowards(coinImageObj.transform.localScale, new Vector2(0.6f, 0.6f), 1 * Time.deltaTime);
        }

        

    }


    IEnumerator slowMotion() 
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

    public IEnumerator coinImageAnim() 
    {
        imageCoinAnimated = true;
       
        yield return new WaitForSeconds(0.1f);
      
        imageCoinAnimated = false;
    }

}
