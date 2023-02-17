using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIStartGame : MonoBehaviour
{
    public static UIStartGame uIStartGame;

    public bool isInStartGame;
    public bool isStarted;
    public bool isMusicVolumeUp;

    public int idLevel;
    public int totalLevel;
    public int levelFarmingValue;

    public string levelType;

    public GameObject[] listUIObject;

    

    [SerializeField] GameObject listAbilityObject;
    [SerializeField] GameObject bossObjectUI;
    

    #region variabel ability icon
    [Header("VARIABEL ABILITY ICON")]

    public string[] abilityLeftName;
    public string[] abilityRightName;
    [SerializeField] string[] strDescLeft;
    [SerializeField] string[] strDescRight;

    [SerializeField] Image imageAbilityLeft;
    [SerializeField] Image imageAbilityRight;
    [SerializeField] Image imageAbilitySelected;

    [SerializeField] TextMeshProUGUI textLeftDesc;
    [SerializeField] TextMeshProUGUI textRightDesc;

    

   

   
    #endregion

    #region variabel ability selector
    [Header("VARIABEL ABILITY SELECT")]
    public int abilitySelectedValue;

    [SerializeField] Button[] listButtonAbility;

    [SerializeField] GameObject[] player;

    int curAbilityA, curAbilityB;
    #endregion

    #region variabel event input listener
    [Header("VARIABEL INPUT EVENT LISTENER")]
    [SerializeField] int highlightListAbilityButtonValue;
    [SerializeField] int[] curValueSelect;

    [SerializeField] GameObject selector;

    #endregion


    bool isGamePad = false;

    

    private void Awake()
    {
        uIStartGame = this;
    }

    private void Start()
    {
        totalLevel = 10;
        if(SceneManagerStatus.sceneManagerStatus.sceneStats == "Level")
        {
            levelFarmingValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]) - idLevel;
            listAbilityObject.SetActive(true);
        }
        else 
        {
            bossObjectUI.SetActive(true);
        }


        isInStartGame = true;
       
        listUIObject[0].SetActive(true);
        for(int j = 1; j < listUIObject.Length; j++) 
        {
            listUIObject[j].SetActive(false);
        }
       
        highlightListAbilityButtonValue = 1;
        #region start ability selector
        startAbilitySelector();
        #endregion

        eventListener();
        if (Music.music.id == "Level")
        {
            Music.music.audioSource.Play();
            Music.music.audioSource.volume = 0.1f;
        }
    }

    private void Update()
    {

        if(SceneManagerStatus.sceneManagerStatus.sceneStats == "Level") 
        {
            #region update ability icon
            abilityIcon();
            #endregion

            compareHighlightValue();


            StartCoroutine(gameStarting());
        }

        if (!UIPauseGame.uIPauseGame.isSceneEnded && Music.music.id=="Level") 
        {
            if (isMusicVolumeUp)
            {
                Music.music.audioSource.volume = Mathf.Lerp(Music.music.audioSource.volume, 0.4f, 2.3f * Time.unscaledDeltaTime);
            }
            if (!isMusicVolumeUp)
            {
                Music.music.audioSource.volume = Mathf.Lerp(Music.music.audioSource.volume, 0.1f, 2.3f * Time.unscaledDeltaTime);
            }
        }
        
        if (GameStarting.gameStarting.isGameStarted) 
        {
           
            listUIObject[0].SetActive(false);
            for (int i = 0; i < player.Length; i++)
            {
                if (player[i] != null)
                {
                    player[i].SetActive(true);
                }
            }
        }


        
    }

    IEnumerator gameStarting()
    {
        if (isStarted)
        {
            listAbilityObject.transform.localScale = Vector2.Lerp(listAbilityObject.transform.localScale,
                new Vector2(0,0),15*Time.deltaTime);
            yield return new WaitForSeconds(0.5f);
            GameStarting.gameStarting.isGameStarted = true;
            isInStartGame = false;
        }

    }
    public void onClickButtonA1()
    {
        isMusicVolumeUp = true;
        SoundEffect.soundEffect.audioSources[6].Play();
        isStarted = true;
        curAbilityA = AbilityInventory.abilityInventory.skill_1;
        abilitySelectedValue = curAbilityA;
        Cursor.visible = false;
        for (int j = 0; j < listButtonAbility.Length; j++)
        {
            listButtonAbility[j].interactable = false;
        }
    }

    public void onClickButtonA2()
    {
        isMusicVolumeUp = true;
        SoundEffect.soundEffect.audioSources[6].Play();
        isStarted = true;
        curAbilityB = AbilityInventory.abilityInventory.skill_2;
        abilitySelectedValue = curAbilityB;
        Cursor.visible = false;
        for (int j = 0; j < listButtonAbility.Length; j++)
        {
            listButtonAbility[j].interactable = false;
        }
    }

    // button di boss level
    public void onClickContinue()
    {
        isMusicVolumeUp = true;
        SoundEffect.soundEffect.audioSources[0].Play();
        Cursor.visible = false;
        GameStarting.gameStarting.isGameStarted = true;
    }

    

    #region event listener
    void eventListener() 
    {
        for(int i = 0; i < listButtonAbility.Length; i++) 
        {
            int valueSelect = curValueSelect[i];

            EventTrigger eventTrigger = listButtonAbility[i].gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((data) => { buttonHighlighted(valueSelect); });
            eventTrigger.triggers.Add(entry);
        }
    }

    void compareHighlightValue() 
    {
        if (highlightListAbilityButtonValue == 1)
        {
            selector.transform.localPosition = new Vector2(-215,-20);
            textLeftDesc.enabled = true;
            textRightDesc.enabled = false;
        }
        else
        {
            selector.transform.localPosition = new Vector2(215, -20);
            textLeftDesc.enabled = false;
            textRightDesc.enabled = true;
        }
    }

    void buttonHighlighted(int value) 
    {
        highlightListAbilityButtonValue = value;
    }
    #endregion

    

    #region ability icon
    private void abilityIcon() 
    {
        imageAbilityLeft.sprite = Resources.Load<Sprite>("Sprite/Ability Card/A" + AbilityInventory.abilityInventory.skill_1);
        imageAbilityRight.sprite = Resources.Load<Sprite>("Sprite/Ability Card/A" + AbilityInventory.abilityInventory.skill_2);

        if (AbilityInventory.abilityInventory.skill_1 == 0) 
        {
            //textLeftDesc.text = strDescLeft[0];
        }
        if (AbilityInventory.abilityInventory.skill_1 == 1)
        {
            //textLeftDesc.text = strDescLeft[1];
        }

        for (int k = 0; k < AbilityInventory.abilityInventory.maxTotalSkill; k++) 
        {
            if (AbilityInventory.abilityInventory.skill_1 == k)
            {
                textLeftDesc.text = strDescLeft[k];
                break;
            }
           
        }
        for(int k = 0; k < AbilityInventory.abilityInventory.maxTotalSkill; k++)
        {
            if (AbilityInventory.abilityInventory.skill_2 == k)
            {
                textRightDesc.text = strDescRight[k];
                break;
            }
        }
        
    }
    #endregion

    #region ability selector
    void startAbilitySelector() 
    {
        curAbilityA = AbilityInventory.abilityInventory.skill_1;
        curAbilityB = AbilityInventory.abilityInventory.skill_2;
    }
    #endregion

}

