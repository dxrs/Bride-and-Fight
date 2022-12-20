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

    public TextMeshProUGUI textTimer;
    public TextMeshProUGUI textOverFinish;

    public bool isStarting;

    public float timerValue;

    [SerializeField] TextMeshProUGUI textTotalCoin;
    [SerializeField] TextMeshProUGUI textTotalCoinEndGame;
    [SerializeField] GameObject[] UI_object;
    [SerializeField] GameObject abilityObject;
    [SerializeField] bool isTimeCountDown;

    //endGame
    [SerializeField] GameObject objectTextEndegame; 

    int totalCoinValue;
    int coinValue;
    bool isCoinDataSaved;

    TimeSpan timePlay;
    

    private void Awake()
    {
        uIManager = this;
    }
    private void Start()
    {
        StartCoroutine(timeCountDownStart());
        coinValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[0]);
        TotalCoin.totalCoin.totalCoinGet = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);
        UI_object[0].SetActive(true); // ui start game
        for (int i = 1; i < UI_object.Length; i++) 
        {
            UI_object[i].SetActive(false);
        }

    }
    private void Update()
    {
        inGameStatus();
        timerEnd();
        StartCoroutine(gameIsStarting());
        if (GameStarting.gameStarting.isGameStarted) 
        {
            UI_object[0].SetActive(false); // ui start game
            UI_object[1].SetActive(true); // ui in game
        }
        else 
        {
            UI_object[1].SetActive(false); // ui in game
        }
       
    }
    void inGameStatus() 
    {
        gameIsPaused();
        textTotalCoin.text = TotalCoin.totalCoin.curCoinGet + "$";
        if (GameOver.gameOver.isGameOver || GameFinish.gameFinish.isGameFinished)
        {
            

            //PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[1] + TotalCoin.totalCoin.curCoinGet, test);
            StartCoroutine(popUpEndGameShow());
            GameStarting.gameStarting.isGameStarted = false;
            //DataCoin.dataCoin.coinDataValue = TotalCoin.totalCoin.curCoinGet;
            textTotalCoinEndGame.text= "+" + TotalCoin.totalCoin.curCoinGet + "$";
           
        }
        if (GameOver.gameOver.isGameOver)
        {
            textOverFinish.text = "GAME OVER";
            
          
        }
        if (GameFinish.gameFinish.isGameFinished)
        {
            textOverFinish.text = "GAME FINISH";
            
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
        if (!GamePaused.gamePaused.isGamePaused && GameStarting.gameStarting.isGameStarted) 
        {
            isTimeCountDown = true;
            
        }
    }
    public void timerStart() 
    {
        if (GameStarting.gameStarting.isGameStarted) 
        {
            isTimeCountDown = true;
        }
      
        
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
                textTimer.text = strTimerPlaying;
            }
           
          

            yield return null;
        }
    }
    IEnumerator gameIsStarting() 
    {
        if (isStarting) 
        {
            
            abilityObject.transform.localPosition = Vector2.Lerp(abilityObject.transform.localPosition, new Vector2(0, -300), 5 * Time.deltaTime);
            yield return new WaitForSeconds(0.8f);
            GameStarting.gameStarting.isGameStarted = true;
        }
    }
    IEnumerator popUpEndGameShow() 
    {
        yield return new WaitForSeconds(1);
        UI_object[2].SetActive(true); // ui end game
        UI_object[1].SetActive(false); // ui in game
    }
    IEnumerator loadToSceneMenu() 
    {
        TotalCoin.totalCoin.totalCoinGet = TotalCoin.totalCoin.totalCoinGet + PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[0]);
        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[1], TotalCoin.totalCoin.totalCoinGet);
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Scene test select level");
    }

    public void onClickContinue() 
    {
        isCoinDataSaved = true;
        if (isCoinDataSaved) 
        {
            PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[0], TotalCoin.totalCoin.curCoinGet);
        }
        StartCoroutine(loadToSceneMenu());
        
    }
    public void onClickRestart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
