using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityButtonList : MonoBehaviour
{
    public static AbilityButtonList abilityButton;


    //public int maxSelectAbility;
    public int[] buttonCurValue;
    public int clickedValue;
    public int highlightedValue;
    public bool isClickedToUpgradePopUp;

    public Button[] abilityListButton;
    [SerializeField] Vector2[] abilityListSelectorPos;
    [SerializeField] GameObject abilityListSelector;

    bool dpadPressed = false;

    private void Awake()
    {
        abilityButton = this;
    }

    private void Start()
    {

        for (int j = 0; j < abilityListButton.Length; j++)
        {
            int buttonValues = buttonCurValue[j];

            abilityListButton[j].onClick.AddListener(() => buttonClicked(buttonValues));
           


            EventTrigger eventTrigger = abilityListButton[j].gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((data) => { ButtonHighlighted(buttonValues); });
            eventTrigger.triggers.Add(entry);

        }

    }
    private void Update()
    {
        for (int i = 0; i < abilityListButton.Length-1; i++)
        {
            if (isClickedToUpgradePopUp)
            {
              
                abilityListButton[i].interactable = false;
            }
            else 
            {
                abilityListButton[i].interactable = true;
            }
           
        }
        for(int x = 0; x < abilityListSelectorPos.Length; x++) 
        {
            if (highlightedValue == x + 1) 
            {
                abilityListSelector.transform.localPosition = abilityListSelectorPos[x];
                break;
            }
        }

        if (highlightedValue > UpgradeSystem.upgradeSystem.totalCurAbility) 
        {
            highlightedValue = UpgradeSystem.upgradeSystem.totalCurAbility;
        }
        //inputChooseAbility();
    }



    void ButtonHighlighted(int value)
    {
        // Mengambil nilai int dari button yang di-highlight
        if(value> UpgradeSystem.upgradeSystem.totalCurAbility) 
        {
            value = UpgradeSystem.upgradeSystem.totalCurAbility;
        }
      
        highlightedValue = value;
    }
     void buttonClicked(int value) 
    {
        //Debug.Log(value);
        clickedValue = value;
        //onEnterAbilitySelect();
        if (UISelectLevelManager.uISelectLevelManager.mouseInputSys)
        {
           
            print(clickedValue);
          
        }

        isClickedToUpgradePopUp = true;
        //UISelectLevelManager.uISelectLevelManager.isGoingToStore = true;



    }

    #region choose ability
    void inputChooseAbility() 
    {
        if(UISelectLevelManager.uISelectLevelManager.isGoingToStore && !isClickedToUpgradePopUp) 
        {
            if(Input.GetAxis("DPadRight")>0 && !dpadPressed
                || Input.GetKeyDown(KeyCode.D)
                || Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                Cursor.visible = false;
                dpadPressed = true;
                highlightedValue++;
                if (highlightedValue > UpgradeSystem.upgradeSystem.totalCurAbility)
                {
                    highlightedValue = 1;
                }
            }
            else if (Input.GetAxis("DPadRight") == 0) 
            {
                dpadPressed = false;
            }

            if(Input.GetAxis("DPadLeft") < 0 && !dpadPressed
                || Input.GetKeyDown(KeyCode.A)
                || Input.GetKeyDown(KeyCode.LeftArrow)) 
            {
                Cursor.visible = false;
                dpadPressed = true;
                highlightedValue--;
                if (highlightedValue < 1)
                {
                    highlightedValue = UpgradeSystem.upgradeSystem.totalCurAbility;
                }
            }
            else if (Input.GetAxis("DPadLeft") == 0)
            {
                dpadPressed = false;
            }
        }
    }
    #endregion

    public void onEnterAbilitySelect()
    {
        Cursor.visible = false;
        isClickedToUpgradePopUp = true;
        for (int j = 0; j <= UpgradeSystem.upgradeSystem.totalCurAbility; j++)
        {
            if (highlightedValue == j)
            {

                clickedValue = highlightedValue;
                print("ability ke " + j);
                break;
            }
        }
        if (!UISelectLevelManager.uISelectLevelManager.mouseInputSys) 
        {
           
        }
       
    }

    public void buttonUpgradeClicked() 
    {
        if (clickedValue == 1) 
        {
            AbilityShadowUpgrade.abilityShadowUpgrade.onClickUpgradeShadow();
            
        }
        if (clickedValue == 2) 
        {
            AbilityInfinityStoneUpgrade.abilityInfinityStoneUpgrade.onClickUpgradeStone();
        }
    }
    
    
}
