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
    int totalAbility;

    bool isCoinDataSaved;
    bool isUsingGamepad = false;
    bool isGoingTransition;
    bool isGetBonusCoin = false;
    bool isOneShot = false;
    

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
        totalAbility= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[4]);


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
        SoundEffect.soundEffect.audioSources[0].Play();
        isGoingTransition = true;
        isCoinDataSaved = true;
        if (GameFinish.gameFinish.isGameFinished) 
        {
            

            if(UIStartGame.uIStartGame.idLevel == curLevelValue) 
            {
                if (curLevelValue == 1)
                {
                    totalAbility++;
                    PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[4], totalAbility);
                }
                if (curLevelValue == 2)
                {
                    totalAbility++;
                    PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[4], totalAbility);
                }
            }
          
            
        }
       
        if (curLevelValue <= UIStartGame.uIStartGame.totalLevel) 
        {
            if (UIStartGame.uIStartGame.idLevel == curLevelValue)
            {
                if (SceneManagerStatus.sceneManagerStatus.sceneStats == "Level")
                {
                    if (isCoinDataSaved)
                    {
                        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[0], totalCoin);
                    }
                }

            }
            else
            {
                if (isCoinDataSaved)
                {
                    PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[0], TotalCoin.totalCoin.curCoinGet);
                }
            }
        }
       
        
        StartCoroutine(loadToSceneSelectLevel());
        listEndGameButton[0].interactable = false;
        listEndGameButton[1].interactable = false;
    }
    public void onClickRestart()
    {
        SoundEffect.soundEffect.audioSources[0].Play();
        isGoingTransition = true;
        listEndGameButton[0].interactable = false;
        listEndGameButton[1].interactable = false;
        SceneManagerCallback.sceneManagerCallback.restartScene();
    }

    #region text animation
    void compareEndGameValue() 
    {
        if(GameFinish.gameFinish.isGameFinished || GameOver.gameOver.isGameOver) 
        {
            if (Music.music.id=="Level") 
            {
                Music.music.audioSource.pitch = 1f;
            }
            
            UIStartGame.uIStartGame.isMusicVolumeUp = false;
            imgObjectCoin.transform.Rotate(Vector3.forward, 50 * Time.deltaTime);
            //Cursor.visible = true;
            //GameStarting.gameStarting.isGameStarted = false;
            textCoin.text = TotalCoin.totalCoin.curCoinGet.ToString();
           
            if (textEndGame.color == new Color(1, 1, 1, 0))
            {
                isEndGameObjectEnable = true;
            }

        }

        if (GameFinish.gameFinish.isGameFinished) 
        {
            if (!isOneShot)
            {
                SoundEffect.soundEffect.audioSources[4].Play();
                isOneShot = true;
            }
            totalCoin = TotalCoin.totalCoin.curCoinGet + bonusCoin;
            UIStartGame.uIStartGame.listUIObject[3].SetActive(true);
            UIStartGame.uIStartGame.listUIObject[1].SetActive(false);
            if (UIStartGame.uIStartGame.idLevel == curLevelValue)
            {
                
                textTotalCoin.text = "You received " + totalCoin + " Coin";
                

                if (SceneManagerStatus.sceneManagerStatus.sceneStats == "Level") 
                {
                    textBonusCoin.enabled = true;
                    textTotalCoin.enabled = true;
                    textCongrats.enabled = true;

                    textBonusCoin.text = "Bonus : " + bonusCoin;

                    if (!isGetBonusCoin)
                    {
                        
                        isGetBonusCoin = true;
                    }
                }
                

            }
            
            StartCoroutine(textEndGameFinish());
            textEndGame.text = "VICTORY";
            
        }

        if (GameOver.gameOver.isGameOver)
        {

            if (!isOneShot)
            {
                SoundEffect.soundEffect.audioSources[5].Play();
                isOneShot = true;
            }
            StartCoroutine(delayPopuEndGame());
            StartCoroutine(textEndGameFailed());
          
            textEndGame.text = "DEFEAT";
            

            if (SceneManagerStatus.sceneManagerStatus.sceneStats == "Level") 
            {
                textRemainingTime.enabled = true;
                remainingTime = UIInGame.uIInGame.timerValue;
                timerCount = TimeSpan.FromSeconds(remainingTime);
                string timer = timerCount.ToString("mm':'ss':'ff");
                textRemainingTime.text = "Remaining time : " + timer;
            }
            
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
