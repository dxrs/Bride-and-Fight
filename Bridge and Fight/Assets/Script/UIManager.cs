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
    [SerializeField] GameObject[] inGamePopUp;
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
        }
    }
    void inGameStatus() 
    {
        if (PlayerDestroy.playerDestroy.isGameOver || GameFinish.gameFinish.isGameFinished)
        {
            StartCoroutine(popUpEndGameShow());
            if (inGamePopUp[0].activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    SceneManager.LoadScene("Scene Menu");
                }

            }
        }
        if (PlayerDestroy.playerDestroy.isGameOver)
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
        if (GameStarting.gameStarting.isGameStarted && !PlayerDestroy.playerDestroy.isGameOver)
        {
            timerStart();
        }
        if (PlayerDestroy.playerDestroy.isGameOver || GameFinish.gameFinish.isGameFinished)
        {
            isTimeCountDown = false;
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
        tmpTimer.enabled = false;
    }
}
