using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityButtonList : MonoBehaviour
{
    public static AbilityButtonList abilityButton;

    public int[] buttonCurValue;
    public int clickedValue;
    public int highlightedValue;
    public bool isClicked;

    public Button[] abilityListButton;
    //
    //
    //[SerializeField] Button buttonUp;

   

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
            if (isClicked)
            {
                //abilityListButton[i].interactable = false;
                abilityListButton[i].interactable = false;
            }
            else 
            {
                abilityListButton[i].interactable = true;
            }
           
        }
        
    }
    void ButtonHighlighted(int value)
    {
        // Mengambil nilai int dari button yang di-highlight
        //Debug.Log(value);
        highlightedValue = value;
    }
    void buttonClicked(int value) 
    {
        //Debug.Log(value);
        clickedValue = value;
        isClicked = true;
        
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
