using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIPauseGame : MonoBehaviour
{
    public static UIPauseGame uIPauseGame;

    public bool isInPauseMenu;

    public bool isSceneEnded;

    [SerializeField] GameObject objectRestartExit;
    [SerializeField] GameObject setting;
    [SerializeField] GameObject postProc;
    [SerializeField] GameObject sceneTransition;
    [SerializeField] GameObject spawnerObject;

    [SerializeField] bool isInSetting;
    [SerializeField] bool isAnimatedTransition;

    [SerializeField] Vector2[] selectorPos;

    [Header("EVENT LISTENER")]
    [SerializeField] Button[] listPauseButton;

    [SerializeField] int[] curValueSelect;
    [SerializeField] int buttonPauseHighlightedValue;
    [SerializeField] int buttonPauseSelectedValue;

    [SerializeField] bool buttoniSClicked;

    [SerializeField] GameObject selector;


    [Header("TOGGLE")]
    [SerializeField] Toggle[] checkListToggleButton;
    [SerializeField] int visualValue;
    [SerializeField] int sfxValue;
    [SerializeField] int musicValue;
    

    private void Awake()
    {
        uIPauseGame = this;
    }

    private void Start()
    {
        eventListener();
        buttonPauseHighlightedValue = 1;


        
        visualValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[8], 1);
        sfxValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[9], 1);
        musicValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[10], 1);
        checkListToggleButton[0].isOn = visualValue == 1;
        checkListToggleButton[1].isOn = sfxValue == 1;
        checkListToggleButton[2].isOn = musicValue == 1;
    }

    private void Update()
    {
        if (isSceneEnded) 
        {
            if (Music.music.id == "Level") 
            {
                Music.music.audioSource.volume = Mathf.Lerp(Music.music.audioSource.volume, 0, 1 * Time.unscaledDeltaTime);
            }
            
        }
        if (!GameOver.gameOver.isGameOver) 
        {
            if (GamePaused.gamePaused.isGamePaused)
            {


                if (!GameOver.gameOver.isGameOver)
                {
                    Time.timeScale = 0;

                }
            }
            else
            {
                buttoniSClicked = false;

                if (!GameOver.gameOver.isGameOver)
                {
                    Time.timeScale = 1;

                }


            }
        }
       

       

        if(GameStarting.gameStarting.isGameStarted 
            && !GameOver.gameOver.isGameOver 
            && !GameFinish.gameFinish.isGameFinished) 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!GamePaused.gamePaused.isGamePaused)
                {
                    UIStartGame.uIStartGame.isMusicVolumeUp = false;
                    SoundEffect.soundEffect.audioSources[11].Play();
                    GamePaused.gamePaused.isGamePaused = true;
                    UIStartGame.uIStartGame.listUIObject[2].SetActive(true);
                    UIStartGame.uIStartGame.listUIObject[1].SetActive(false);
                    //Cursor.visible = true;
                    if (buttoniSClicked) 
                    {
                        buttoniSClicked = false;
                    }

                }
                else
                {
                    UIStartGame.uIStartGame.isMusicVolumeUp = true;
                    GamePaused.gamePaused.isGamePaused = false;
                    UIStartGame.uIStartGame.listUIObject[2].SetActive(false);
                    UIStartGame.uIStartGame.listUIObject[1].SetActive(true);
                    //Cursor.visible = false;
                    isInSetting = false;
                    buttonPauseHighlightedValue = 1;
                }
            }
        }

        

        if (isInSetting) 
        {
            objectRestartExit.transform.localPosition = Vector2.Lerp(objectRestartExit.transform.localPosition,
                new Vector2(0, -120), 10 * Time.unscaledDeltaTime);
            setting.SetActive(true);
        }
        else 
        {
            
            objectRestartExit.transform.localPosition = Vector2.MoveTowards(objectRestartExit.transform.localPosition,
               new Vector2(0, 0), 300 * Time.unscaledDeltaTime);
            setting.SetActive(false);
        }

        compareSelectorPos();
        compareButtonCLickValue();
        animatedTransition();

        if (visualValue == 0) 
        {
            postProc.SetActive(false);
        }
        else 
        {
            postProc.SetActive(true);
        }
        

    }
    void animatedTransition()
    {
        if (isAnimatedTransition) 
        {
            sceneTransition.transform.localScale = Vector2.MoveTowards(sceneTransition.transform.localScale,
                new Vector2(30.0f, 30.0f),
                100 * Time.unscaledDeltaTime);
        }
    }
    void compareSelectorPos() 
    {
        if (GamePaused.gamePaused.isGamePaused) 
        {
            for(int j = 0; j < selectorPos.Length; j++) 
            {
                if (buttonPauseHighlightedValue == j + 1) 
                {
                    selector.transform.localPosition = selectorPos[j];
                }
            }
        }
    }


    void eventListener() 
    {
        do
        {
            for(int j=0; j < listPauseButton.Length; j++) 
            {
                int buttonValue = curValueSelect[j];

                listPauseButton[j].onClick.AddListener(() => buttonPauseClick(buttonValue));

                EventTrigger eventTrigger = listPauseButton[j].gameObject.AddComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback.AddListener((data) => { buttonPauseHighlighted(buttonValue); });
                eventTrigger.triggers.Add(entry);
            }

        } while (GamePaused.gamePaused.isGamePaused && !isInSetting);
    }

    void compareButtonCLickValue() 
    {
        
        if (buttoniSClicked) 
        {
            if (buttonPauseSelectedValue == 1) 
            {
                UIStartGame.uIStartGame.isMusicVolumeUp = true;
                GamePaused.gamePaused.isGamePaused = false;
                UIStartGame.uIStartGame.listUIObject[2].SetActive(false);
                UIStartGame.uIStartGame.listUIObject[1].SetActive(true);
                //Cursor.visible = false;
                buttonPauseHighlightedValue = 1;
                
            }

            if (buttonPauseSelectedValue == 3) 
            {
                isSceneEnded = true;
                isAnimatedTransition = true;
                GamePaused.gamePaused.isGamePaused = false;
                Destroy(spawnerObject);
                SceneManagerCallback.sceneManagerCallback.restartScene();
            }
            if (buttonPauseSelectedValue == 4)
            {
                isSceneEnded = true;
                isAnimatedTransition = true;
                GamePaused.gamePaused.isGamePaused = false;

                Destroy(spawnerObject);
                StartCoroutine(SceneManagerCallback.sceneManagerCallback.loadToMenu());
            }

            if(buttonPauseSelectedValue==3 || buttonPauseSelectedValue == 4) 
            {
                
                for (int j = 0; j < listPauseButton.Length; j++) 
                {
                    listPauseButton[j].interactable = false;
                }
            }
        }
    }

    void buttonPauseClick(int value) 
    {
        SoundEffect.soundEffect.audioSources[0].Play();
        if (!isInSetting&& buttonPauseHighlightedValue != 2) 
        {
            buttonPauseSelectedValue = value;
            buttoniSClicked = true;
            
        }
       
       
    }

    void buttonPauseHighlighted(int value) 
    {
        if (!isInSetting) 
        {
            buttonPauseHighlightedValue = value;
        }
            
    }

 

    public void onClickButtonSetting() 
    {
        if (!isInSetting) 
        {
            isInSetting = true;
        }
        else 
        {
            isInSetting = false;
        }
    }

    #region toggle button
    public void toggleVisual() 
    {
        if (GamePaused.gamePaused.isGamePaused)
        {
            SoundEffect.soundEffect.audioSources[3].Play();
        }
        visualValue = checkListToggleButton[0].isOn ? 1 : 0;
        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[8], visualValue);
        PlayerPrefs.Save();
    }
    public void toggleSFX() 
    {
       
        sfxValue = checkListToggleButton[1].isOn ? 1 : 0;
        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[9], sfxValue);
        PlayerPrefs.Save();
        if (sfxValue == 0)
        {
            SoundEffect.soundEffect.objectDisable();
        }
        if (sfxValue == 1)
        {
            SoundEffect.soundEffect.audioSources[3].Play();
            SoundEffect.soundEffect.objectEnable();
        }
    }

    public void toggleMusic() 
    {
        if (GamePaused.gamePaused.isGamePaused) 
        {
            SoundEffect.soundEffect.audioSources[3].Play();
        }
       
        musicValue = checkListToggleButton[2].isOn ? 1 : 0;
        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[10], musicValue);
        PlayerPrefs.Save();
        if (musicValue == 0)
        {
            Music.music.objectDisable();
        }
        if (musicValue == 1)
        {
            Music.music.objectEnable();
            if (Music.music.id == "Level")
            {
                Music.music.audioSource.Play();
                Music.music.audioSource.volume = 0.4f;
            }
        }
    }
    #endregion


    
}