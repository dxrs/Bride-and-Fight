using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class AbilitySelector : MonoBehaviour
{
    //public static AbilitySelector abilitySelector;

    public int abilitySelected;

    [SerializeField] Button[] buttonAbility;
    [SerializeField] GameObject[] player;

    [Header("Input Event")]
    [SerializeField] int[] curValueSelect;
    [SerializeField] int highlightValue;
    [SerializeField] Button[] abilityListButtonSelector;
    [SerializeField] TextMeshProUGUI textSelectStatus;
    [SerializeField] GameObject selector;

    bool dpadPressed = false;

    int curSkill_1, curSkill_2;


    private void Awake()
    {
        //abilitySelector = this;
        //Cursor.visible = false;
    }

    private void Start()
    {

        
        //textSelectStatus.text = "Keyboard/Gamepad";
        curSkill_1 = AbilityInventory.abilityInventory.skill_1;
        curSkill_2 = AbilityInventory.abilityInventory.skill_2;

        for(int i = 0; i < abilityListButtonSelector.Length; i++) 
        {
            int valuesSelect = curValueSelect[i];

            EventTrigger eventTrigger = abilityListButtonSelector[i].gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((data) => { buttonHighlighted(valuesSelect); });
            eventTrigger.triggers.Add(entry);
        }
    }
    private void Update()
    {
        if (GameStarting.gameStarting.isGameStarted)
        {
            for (int i = 0; i < player.Length; i++)
            {
                if (player[i] != null)
                {
                    player[i].SetActive(true);
                }
            }
            
        }
        
        if (highlightValue == 1) 
        {
            selector.transform.localPosition = new Vector2(0, 0);
        }
        else 
        {
            selector.transform.localPosition = new Vector2(335, 0);
        }
        //selectorInput();
    }

    // input select ability when start
    #region

    private void buttonHighlighted(int value) 
    {
        highlightValue = value;
    }

    void selectorInput() 
    {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            // tampilkan cursor jika mouse di-swipe
            textSelectStatus.text = "Mouse";
            Cursor.visible = true;
        }

        if (!PlayerNumber.playerNumber.isSoloMode) 
        {
            if (Input.GetAxis("DPadLeft") < 0 && !dpadPressed || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                textSelectStatus.text = "Keyboard/Gamepad";
                Cursor.visible = false;
                highlightValue--;
                if (highlightValue < 1) { highlightValue = 2; }
                dpadPressed = true;
            }
            else if (Input.GetAxis("DPadLeft") == 0)
            {
                dpadPressed = false;
            }


            if (Input.GetAxis("DPadRight") > 0 && !dpadPressed || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                textSelectStatus.text = "Keyboard/Gamepad";
                Cursor.visible = false;
                highlightValue++;
                if (highlightValue > 2) { highlightValue = 1; }
                dpadPressed = true;
            }
            else if (Input.GetAxis("DPadRight") == 0)
            {
                dpadPressed = false;
            }
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
            {
                textSelectStatus.text = "Keyboard";
                Cursor.visible = false;
                highlightValue--;
                if (highlightValue < 1) { highlightValue = 2; }
                dpadPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                textSelectStatus.text = "Keyboard";
                Cursor.visible = false;
                highlightValue++;
                if (highlightValue > 2) { highlightValue = 1; }
            }
        }

        if (PlayerNumber.playerNumber.isSoloMode) 
        {
            if (Input.GetKeyDown(KeyCode.Return)) 
            {
                if (highlightValue == 1) 
                {
                    //UIManager.uIManager.isStarting = true;
                    curSkill_1 = AbilityInventory.abilityInventory.skill_1;
                    abilitySelected = curSkill_1;
                    Cursor.visible = false;
                    for (int x = 0; x < buttonAbility.Length; x++)
                    {
                        buttonAbility[x].enabled = false;
                    }
                }
                if (highlightValue==2) 
                {
                    //UIManager.uIManager.isStarting = true;
                    curSkill_2 = AbilityInventory.abilityInventory.skill_2;
                    abilitySelected = curSkill_2;
                    Cursor.visible = false;
                    for (int x = 0; x < buttonAbility.Length; x++)
                    {
                        buttonAbility[x].enabled = false;
                    }
                }
            }
        }
        if (!PlayerNumber.playerNumber.isSoloMode) 
        {
            if (Input.GetButton("Abutton") || Input.GetKeyDown(KeyCode.Return))
            {
                if (highlightValue == 1) 
                {
                    //UIManager.uIManager.isStarting = true;
                    curSkill_1 = AbilityInventory.abilityInventory.skill_1;
                    abilitySelected = curSkill_1;
                    Cursor.visible = false;
                    for (int x = 0; x < buttonAbility.Length; x++)
                    {
                        buttonAbility[x].enabled = false;
                    }
                }
                if (highlightValue == 2)
                {
                    //UIManager.uIManager.isStarting = true;
                    curSkill_2 = AbilityInventory.abilityInventory.skill_2;
                    abilitySelected = curSkill_2;
                    Cursor.visible = false;
                    for (int x = 0; x < buttonAbility.Length; x++)
                    {
                        buttonAbility[x].enabled = false;
                    }
                }
            }
        }



       


    }

    public void onClickButtonA() 
    {
        //GameStarting.gameStarting.isGameStarted=true;
        //UIManager.uIManager.isStarting = true;
        curSkill_1 = AbilityInventory.abilityInventory.skill_1;
        abilitySelected = curSkill_1;
        Cursor.visible = false;
        for(int x=0; x < buttonAbility.Length; x++) 
        {
            buttonAbility[x].enabled = false;
        }
        
    }

    public void onClickButtonB() 
    {
        //GameStarting.gameStarting.isGameStarted = true;
        //UIManager.uIManager.isStarting = true;
        curSkill_2 = AbilityInventory.abilityInventory.skill_2;
        abilitySelected = curSkill_2;
        Cursor.visible = false;
        for (int x = 0; x < buttonAbility.Length; x++)
        {
            buttonAbility[x].enabled = false;
        }
    }
    #endregion

}
