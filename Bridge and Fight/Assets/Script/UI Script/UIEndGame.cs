using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIEndGame : MonoBehaviour
{
    public static UIEndGame uIEndGame;

    public bool isInEndGame;

    [SerializeField] TextMeshProUGUI textEndGame;
    [SerializeField] TextMeshProUGUI textCoin;
    [SerializeField] TextMeshProUGUI textBonusCoin;
    [SerializeField] TextMeshProUGUI textTotalCoin;
    [SerializeField] TextMeshProUGUI textRemainingTime;
    [SerializeField] TextMeshProUGUI textInfoLevel;
    [SerializeField] TextMeshProUGUI textCongrats;

    [SerializeField] int bonusCoin;
    [SerializeField] int totalCoin;

    [SerializeField] float remainingTime;

    [SerializeField] bool isEndGameObjectEnable;

    [SerializeField] GameObject endGameObject;
    [SerializeField] GameObject sceneTransition;
    [SerializeField] GameObject imgObjectCoin;

    #region variabel event listener
    [Header("VARIABEL EVENT LISTENER")]
    [SerializeField] Button[] listEndGameButton;
    [SerializeField] GameObject selector;
    [SerializeField] int[] curValueSelect;
    [SerializeField] int highlightListEndGameButtonValue;
    #endregion

    int curLevelValue;

    bool isCoinDataSaved;
    bool isUsingGamepad = false;
    bool isGoingTransition;
    bool isGetBonusCoin = false;
    

    float lerpingTime = 0.5f;
    float curLerpingTime = 0;

    TimeSpan timerCount;

    private void Awake()
    {
        uIEndGame = this;
    }

    private void Start()
    {
        TotalCoin.totalCoin.totalCoinGet = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);
        curLevelValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);

        highlightListEndGameButtonValue = 1;

        eventListener();
        textBonusCoin.enabled = false;
        textRemainingTime.enabled = false;
        textTotalCoin.enabled = false;
        textCongrats.enabled = false;
    }

    private void Update()
    {
        textInfoLevel.text = "Level " + UIStartGame.uIStartGame.idLevel;

        if(GameFinish.gameFinish.isGameFinished || GameOver.gameOver.isGameOver) 
        {
            //UIStartGame.uIStartGame.listUIObject[3].SetActive(true);
        }

        if (isGoingTransition) 
        {
            sceneTransition.transform.localScale = Vector2.MoveTowards(sceneTransition.transform.localScale,
                new Vector2(30.0f, 30.0f),
                100 * Time.deltaTime);
        }
        

        compareEndGameValue();
        compareHighlightValue();
        

    }

    IEnumerator loadToSceneSelectLevel() 
    {
        TotalCoin.totalCoin.totalCoinGet = TotalCoin.totalCoin.totalCoinGet +
            PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[0]);
        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[1], TotalCoin.totalCoin.totalCoinGet);

        if(UIStartGame.uIStartGame.idLevel == curLevelValue && GameFinish.gameFinish.isGameFinished) 
        {
            curLevelValue++;
            PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[6], curLevelValue);
        }

        yield return new WaitForSeconds(3);

        SceneManagerCallback.sceneManagerCallback.keSceneSelectLevel();
    }

    public void onClickContinue()
    {
        isGoingTransition = true;
        isCoinDataSaved = true;
        if (UIStartGame.uIStartGame.idLevel == curLevelValue) 
        {
            if (isCoinDataSaved)
            {
                PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[0], totalCoin);
            }
        }
        else 
        {
            if (isCoinDataSaved)
            {
                PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[0], TotalCoin.totalCoin.curCoinGet);
            }
        }
        
        StartCoroutine(loadToSceneSelectLevel());
        listEndGameButton[0].interactable = false;
        listEndGameButton[1].interactable = false;
    }
    public void onClickRestart()
    {
        isGoingTransition = true;
        listEndGameButton[0].interactable = false;
        listEndGameButton[1].interactable = false;
        //SceneManagerCallback.sceneManagerCallback.restartScene();
    }

    #region text animation
    void compareEndGameValue() 
    {
        if(GameFinish.gameFinish.isGameFinished || GameOver.gameOver.isGameOver) 
        {
            GameStarting.gameStarting.isGameStarted = false;
            textCoin.text = TotalCoin.totalCoin.curCoinGet.ToString();
           
            if (textEndGame.color == new Color(1, 1, 1, 0))
            {
                isEndGameObjectEnable = true;
            }
        }

        if (GameFinish.gameFinish.isGameFinished) 
        {
            totalCoin = TotalCoin.totalCoin.curCoinGet + bonusCoin;
            UIStartGame.uIStartGame.listUIObject[3].SetActive(true);
            UIStartGame.uIStartGame.listUIObject[1].SetActive(false);
            if (UIStartGame.uIStartGame.idLevel == curLevelValue)
            {
                textBonusCoin.enabled = true;
                textTotalCoin.enabled = true;
                textCongrats.enabled = true;
                imgObjectCoin.transform.localPosition = new Vector2(-865, imgObjectCoin.transform.localPosition.y);
                textBonusCoin.text = "+ Bonus Coin + " + bonusCoin;
                textTotalCoin.text ="You received " + totalCoin + " Coin";
                if (!isGetBonusCoin)
                {
                    //TotalCoin.totalCoin.curCoinGet = TotalCoin.totalCoin.curCoinGet + bonusCoin;
                    isGetBonusCoin = true;
                }

            }
            else 
            {
                imgObjectCoin.transform.localPosition = new Vector2(0, imgObjectCoin.transform.localPosition.y);
            }
            StartCoroutine(textEndGameFinish());
            textEndGame.text = "VICTORY";
            
        }

        if (GameOver.gameOver.isGameOver)
        {
            
            textRemainingTime.enabled = true;
            StartCoroutine(delayPopuEndGame());
            StartCoroutine(textEndGameFailed());
            remainingTime = UIInGame.uIInGame.timerValue;
            timerCount = TimeSpan.FromSeconds(remainingTime);
            string timer = timerCount.ToString("mm':'ss':'ff");
            textRemainingTime.text = "Remaining time : " + timer;
            textEndGame.text = "DEFEAT";
            //imgObjectCoin.transform.localPosition = new Vector2(0, imgObjectCoin.transform.localPosition.y);
        }

        if (isEndGameObjectEnable) 
        {
            endGameObject.SetActive(true);
        }

        
        
    }

    

    IEnumerator delayPopuEndGame() 
    {
        yield return new WaitForSeconds(1);
        UIStartGame.uIStartGame.listUIObject[3].SetActive(true);
        UIStartGame.uIStartGame.listUIObject[1].SetActive(false);
    }

    IEnumerator textEndGameFinish()
    {
        yield return new WaitForSeconds(2f);

        curLerpingTime += Time.deltaTime;
        float t = curLerpingTime / lerpingTime;
        textEndGame.color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), t);
    }

    IEnumerator textEndGameFailed()
    {
        yield return new WaitForSeconds(3f);

        curLerpingTime += Time.deltaTime;
        float t = curLerpingTime / lerpingTime;
        textEndGame.color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), t);
    }
    #endregion

    #region event listener
    void eventListener()
    {


        do
        {
            for (int j = 0; j < listEndGameButton.Length; j++)
            {
                int valueSelect = curValueSelect[j];

                EventTrigger eventTrigger = listEndGameButton[j].gameObject.AddComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback.AddListener((data) => { buttonHighlighted(valueSelect); });
                eventTrigger.triggers.Add(entry);
            }
        } while (isEndGameObjectEnable);


    }

    void compareHighlightValue() 
    {
        if (highlightListEndGameButtonValue == 1) 
        {
            selector.transform.localPosition = new Vector2(selector.transform.localPosition.x, -320);
        }
        else 
        {
            selector.transform.localPosition = new Vector2(selector.transform.localPosition.x, -450);
        }
    }
    void buttonHighlighted(int value)
    {
        highlightListEndGameButtonValue = value;
    }
    #endregion



    
}
