using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager uIManager;
     
    public AudioSource aSource;
    public AudioClip clipnya;

    public TextMeshProUGUI textTimer;
    public TextMeshProUGUI textOverFinish;

    public bool isStarting;

    public float timerValue;

    public int idLevel;

    [SerializeField] TextMeshProUGUI textTotalCoin;
    [SerializeField] TextMeshProUGUI textTotalCoinEndGame;
    [SerializeField] GameObject[] UI_object;
    [SerializeField] GameObject abilityObject;
    [SerializeField] bool isTimeCountDown;
    [SerializeField] int curLevelValue;

    //endGame
    [Header("End Game Interactive UI Function")]
    [SerializeField] GameObject objectTextEndegame;
    [SerializeField] GameObject buttonSelector;
    [SerializeField] GameObject sceneTrasisi;
    [SerializeField] GameObject objectEndGame;
    [SerializeField] int[] curValueSelect;
    [SerializeField] int highlightedValue;
    [SerializeField] Button[] endGameListButton;
    [SerializeField] TextMeshProUGUI textSelectStatus;


    int totalCoinValue;
    int coinValue;
    bool isCoinDataSaved;
    bool dpadPressed = false;
    bool isEnabled = false;
    bool goingTransition = false;
    Vector2 targetScale = new Vector2(1.5f, 1.5f); // text finish/game over

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
        objectEndGame.SetActive(false);
        
        for (int i = 1; i < UI_object.Length; i++) 
        {
            UI_object[i].SetActive(false);
        }
        //textSelectStatus.text = "Keyboard/Gamepad";
        //endGame function
        eventPointerEnter();
        curLevelValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);

    }
    private void Update()
    {
        inGameStatus();
        timerEnd();
        StartCoroutine(gameIsStarting());
        if (GameStarting.gameStarting.isGameStarted && !GamePaused.gamePaused.isGamePaused) 
        {
            UI_object[0].SetActive(false); // ui start game
            UI_object[1].SetActive(true); // ui in game
        }
        else 
        {
            UI_object[1].SetActive(false); // ui in game
        }

        // khusus endGame
        #region
        scalingTextStatusEndGame();
        objectEndGameActive();
        compareHighLightValue();
        //inputKeyboardOnly();
        //inputKeyboardOrGamePad();
        fadeInStart();
        #endregion

    }
    void inGameStatus() 
    {
        gameIsPaused();
        textTotalCoin.text = TotalCoin.totalCoin.curCoinGet.ToString();
        if (GameOver.gameOver.isGameOver || GameFinish.gameFinish.isGameFinished)
        {
            

            //PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[1] + TotalCoin.totalCoin.curCoinGet, test);
            StartCoroutine(popUpEndGameShow());
            GameStarting.gameStarting.isGameStarted = false;
            //DataCoin.dataCoin.coinDataValue = TotalCoin.totalCoin.curCoinGet;
            textTotalCoinEndGame.text= "+" + TotalCoin.totalCoin.curCoinGet;
           
        }
        if (GameOver.gameOver.isGameOver)
        {
            textOverFinish.text = "DEFATED";
            
          
        }
        if (GameFinish.gameFinish.isGameFinished)
        {
            textOverFinish.text = "VICTORY";
            
            
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
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                // tampilkan cursor jika mouse di-swipe
                textSelectStatus.text = "Mouse";
                Cursor.visible = true;
            }
        }
        if (!GamePaused.gamePaused.isGamePaused && GameStarting.gameStarting.isGameStarted) 
        {
            isTimeCountDown = true;
            
        }
    }
     void timerStart() 
    {
        if (GameStarting.gameStarting.isGameStarted && SceneManagerStatus.sceneManagerStatus.sceneStats != "Level Bos") 
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
                    UI_object[3].SetActive(true);
                    UI_object[1].SetActive(false);
                }
                else
                {
                    UI_object[3].SetActive(false);
                    UI_object[1].SetActive(true);
                    GamePaused.gamePaused.isGamePaused = false;
                    if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                    {
                        // tampilkan cursor jika mouse di-swipe
                        //textSelectStatus.text = "Mouse";
                        Cursor.visible = true;
                        
                    }
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
        if (goingTransition) 
        {
           
        }
         yield return new WaitForSeconds(3);

            SceneManagerCallback.sceneManagerCallback.keSceneSelectLevel();
    }


    // endGame function
    #region

    void fadeInStart() 
    {
        if (goingTransition) 
        {
            sceneTrasisi.transform.localScale = Vector2.MoveTowards(sceneTrasisi.transform.localScale, 
                new Vector2(30.0f, 30.0f), 
                100 * Time.deltaTime);
        }
    }

    void scalingTextStatusEndGame() 
    {
        
        
        if(GameFinish.gameFinish.isGameFinished || GameOver.gameOver.isGameOver) 
        {
            StartCoroutine(waitToScale());
        }
    }

    void objectEndGameActive() 
    {
        if (isEnabled) 
        {
            objectEndGame.SetActive(true);
        }
    }

    void eventPointerEnter()
    {
        do
        {
            for (int i = 0; i < endGameListButton.Length; i++)
            {
                int valuesSelect = curValueSelect[i];

                EventTrigger eventTrigger = endGameListButton[i].gameObject.AddComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback.AddListener((data) => { buttonHighlighted(valuesSelect); });
                eventTrigger.triggers.Add(entry);



            }
        } while (isEnabled == true);

      
    }

    void compareHighLightValue() 
    {
        if (highlightedValue == 1) 
        {
            buttonSelector.transform.localPosition = new Vector2(buttonSelector.transform.localPosition.x,
                -465f);
        }
        if (highlightedValue == 2) 
        {
            buttonSelector.transform.localPosition = new Vector2(buttonSelector.transform.localPosition.x,
                -550f);
        }
    }
    private void buttonHighlighted(int value)
    {
        highlightedValue = value;
    }

    void inputKeyboardOnly() 
    {
        if (PlayerNumber.playerNumber.isSoloMode) 
        {
            if (GameOver.gameOver.isGameOver || GameFinish.gameFinish.isGameFinished) 
            {
                if (isEnabled && !goingTransition) 
                {
                    if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        textSelectStatus.text = "Keyboard/Gamepad";
                        Cursor.visible = false;
                        highlightedValue++;
                        if (highlightedValue > 2) 
                        {
                            highlightedValue = 1;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
                    {
                        textSelectStatus.text = "Keyboard/Gamepad";
                        Cursor.visible = false;
                        highlightedValue--;
                        if (highlightedValue < 1)
                        {
                            highlightedValue = 2;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Return)) 
                    {
                        if (highlightedValue == 1)
                        {
                            goingTransition = true;
                            isCoinDataSaved = true;
                            if (isCoinDataSaved)
                            {
                                PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[0], TotalCoin.totalCoin.curCoinGet);
                            }
                            StartCoroutine(loadToSceneMenu());
                            endGameListButton[0].enabled = false;
                            endGameListButton[1].enabled = false;
                        }
                        if (highlightedValue == 2)
                        {
                            goingTransition = true;
                            endGameListButton[0].enabled = false;
                            endGameListButton[1].enabled = false;
                            SceneManagerCallback.sceneManagerCallback.restartScene();
                        }
                    }
                }
            }
        }
      
    }

    void inputKeyboardOrGamePad() 
    {
        if (!PlayerNumber.playerNumber.isSoloMode) 
        {
            if (GameOver.gameOver.isGameOver || GameFinish.gameFinish.isGameFinished)
            {
                if(isEnabled && !goingTransition) 
                {
                    if (Input.GetAxis("DPadUp") > 0 && !dpadPressed)
                    {
                        textSelectStatus.text = "Keyboard/Gamepad";
                        dpadPressed = true;
                        Cursor.visible = false;
                        highlightedValue++;
                        if (highlightedValue > 2)
                        {
                            highlightedValue = 1;
                        }
                    }
                    else if (Input.GetAxis("DPadUp") == 0)
                    {
                        dpadPressed = false;
                    }

                    if (Input.GetAxis("DPadDown") < 0 && !dpadPressed) 
                    {
                        textSelectStatus.text = "Keyboard/Gamepad";
                        dpadPressed = true;
                        Cursor.visible = false;
                        highlightedValue--;
                        if (highlightedValue < 1)
                        {
                            highlightedValue = 2;
                        }
                    }else if (Input.GetAxis("DPadDown") == 0) 
                    {
                        dpadPressed = false;
                    }

                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetButton("Abutton")) 
                    {
                        if (highlightedValue == 1) 
                        {
                            goingTransition = true;
                            isCoinDataSaved = true;
                            if (isCoinDataSaved)
                            {
                                PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[0], TotalCoin.totalCoin.curCoinGet);
                            }
                            StartCoroutine(loadToSceneMenu());
                            endGameListButton[0].enabled = false;
                            endGameListButton[1].enabled = false;
                        }
                        if (highlightedValue == 2) 
                        {
                            goingTransition = true;
                            endGameListButton[0].enabled = false;
                            endGameListButton[1].enabled = false;
                            SceneManagerCallback.sceneManagerCallback.restartScene();
                        }
                    }
                }
               
            }
        }
    }

    IEnumerator waitToScale() 
    {
        yield return new WaitForSeconds(1f);
        objectTextEndegame.transform.localScale = Vector2.MoveTowards(objectTextEndegame.transform.localScale,
                targetScale, 2f * Time.deltaTime);
        yield return new WaitForSeconds(1.35f);
        isEnabled = true;
    }

   

    public void onClickContinue() 
    {
        goingTransition = true;
        isCoinDataSaved = true;
        if (isCoinDataSaved) 
        {
            PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[0], TotalCoin.totalCoin.curCoinGet);
        }
        StartCoroutine(loadToSceneMenu());
        endGameListButton[0].enabled = false;
        endGameListButton[1].enabled = false;
        
    }
    public void onClickRestart() 
    {
       
        goingTransition = true;
        endGameListButton[0].enabled = false;
        endGameListButton[1].enabled = false;
        SceneManagerCallback.sceneManagerCallback.restartScene();
    }
    #endregion
}
