using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager uIManager;

    public AudioSource aSource;
    public AudioClip clipnya;

    public TextMeshProUGUI tmpTimer;
    public TextMeshProUGUI tmpOverFinish;
    public TextMeshProUGUI tmpLevelMenu;

    

    public float timerValue;

    [SerializeField] TextMeshProUGUI tmpTotalCoin;
    [SerializeField] GameObject[] inGamePopUp;
    [SerializeField] GameObject inGameUI;
    [SerializeField] bool isTimeCountDown;
    TimeSpan timePlay;
    

    private void Awake()
    {
        uIManager = this;
    }
    private void Start()
    {
        StartCoroutine(timeCountDownStart());
    }
    private void Update()
    {
        inGameStatus();
        timerEnd();
        if (GameStarting.gameStarting.isGameStarted) 
        {
            inGamePopUp[1].SetActive(false);
            inGameUI.SetActive(true);
        }
        else 
        {
            inGameUI.SetActive(false);
        }
    }
    void inGameStatus() 
    {
        gameIsPaused();
        tmpTotalCoin.text = "=" + TotalCoin.totalCoin.curCoinGet + "$";
        if (GameOver.gameOver.isGameOver || GameFinish.gameFinish.isGameFinished)
        {
            StartCoroutine(popUpEndGameShow());
            GameStarting.gameStarting.isGameStarted = false;
            if (inGamePopUp[0].activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    SceneManager.LoadScene("Scene Menu");
                }

            }
        }
        if (GameOver.gameOver.isGameOver)
        {
            tmpOverFinish.text = "GAME OVER";
            tmpLevelMenu.text = "ENTER - RESTART";
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (GameFinish.gameFinish.isGameFinished)
        {
            tmpOverFinish.text = "GAME FINISH";
            tmpLevelMenu.text = "ENTER - NEXT LEVEL";
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if (GameStarting.gameStarting.isGameStarted && !GameOver.gameOver.isGameOver)
        {
            timerStart();
        }
        if (GameOver.gameOver.isGameOver 
            || GameFinish.gameFinish.isGameFinished 
            || GamePaused.gamePaused.isGamePaused)
        {
            isTimeCountDown = false;
            Cursor.visible = true;
        }
        if (!GamePaused.gamePaused.isGamePaused) 
        {
            isTimeCountDown = true;
            
        }
    }
    public void timerStart() 
    {
        isTimeCountDown = true;
        
    }
    void timerEnd() 
    {
        
        if (timerValue <= 0) 
        {
            GameFinish.gameFinish.isGameFinished = true;
            isTimeCountDown = false;
            timerValue = 0; 
        }
    }

    void gameIsPaused() 
    {
        if(!GameOver.gameOver.isGameOver
            &&!GameFinish.gameFinish.isGameFinished
            && GameStarting.gameStarting.isGameStarted) 
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (!GamePaused.gamePaused.isGamePaused)
                {
                    Cursor.visible = false;
                    GamePaused.gamePaused.isGamePaused = true;
                }
                else
                {
                    GamePaused.gamePaused.isGamePaused = false;
                    Cursor.visible = true;
                }
            }
        }
        
    }
    IEnumerator timeCountDownStart() 
    {
        while (true) 
        {
            if (isTimeCountDown) 
            {
                timerValue -= Time.deltaTime;
                timePlay = TimeSpan.FromSeconds(timerValue);
                string strTimerPlaying = timePlay.ToString("mm':'ss':'ff");
                tmpTimer.text = strTimerPlaying;
            }
           
          

            yield return null;
        }
    }
    IEnumerator popUpEndGameShow() 
    {
        yield return new WaitForSeconds(1);
        inGamePopUp[0].SetActive(true);
        inGameUI.SetActive(false);
    }
}
