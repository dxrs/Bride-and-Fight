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

    public int idLevel;
    public int totalLevel;

    public GameObject[] listUIObject;

    [SerializeField] GameObject listAbilityObject;
    [SerializeField] GameObject bossObjectUI;
    

    #region variabel ability icon
    [Header("VARIABEL ABILITY ICON")]

    public string[] abilityLeftName;
    public string[] abilityRightName;

    [SerializeField] Image imageAbilityLeft;
    [SerializeField] Image imageAbilityRight;
    [SerializeField] Image imageAbilitySelected;

   

   
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
        totalLevel = 4;
        if(SceneManagerStatus.sceneManagerStatus.sceneStats == "Level") 
        {
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
        }
        else
        {
            selector.transform.localPosition = new Vector2(215, -20);
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

