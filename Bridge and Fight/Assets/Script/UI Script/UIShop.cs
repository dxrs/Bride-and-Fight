using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIShop : MonoBehaviour
{
    public static UIShop uIShop;

    public bool isInShop;

    public bool isButtonAbilityClicked;

    [SerializeField] Button buttonBackToSelectLevel;

    [SerializeField] Image shadowEffect;

    [SerializeField] TextMeshProUGUI textCoin;

    [SerializeField] GameObject upgradeAbilityObj;

    [Header("EVENT LISTENER")]
    public int buttonAbilityClickValue;
    [SerializeField] int[] curValueSelect;
    [SerializeField] int buttonAbilityHighlightValue;

    [SerializeField] Button[] listAbilityButton;

    [SerializeField] GameObject selector;
    [SerializeField] GameObject[] selectorPosObj;

    



    [Header("UI UPGRADE ABILITY")]
    [SerializeField] Button[] listButtonUpgradeAbility;

    bool isUsingGamepad = false;
    bool isAnimatedPopUp;
    int coin;
    int totalAbility;

    private void Awake()
    {
        uIShop = this;
    }

    private void Start()
    {
        coin = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[0]);
        totalAbility= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[4]);
        eventListener();
        
    }

    private void Update()
    {
        textCoin.text=coin.ToString();
        if (!UISelectLevel.uiselectLevel.isGoingToStore || isButtonAbilityClicked) 
        {
            

            for (int j = 0; j < listAbilityButton.Length; j++)
            {
                listAbilityButton[j].interactable = false;
            }

            buttonBackToSelectLevel.interactable = false;
        }

        if (isButtonAbilityClicked) 
        {
            shadowEffect.enabled = false;
            isAnimatedPopUp = true;

            //listButtonUpgradeAbility[0].interactable = true;
            listButtonUpgradeAbility[1].interactable = true;
        }
        else 
        {
            shadowEffect.enabled = true;
            isAnimatedPopUp = false;

            //listButtonUpgradeAbility[0].interactable =false;
            listButtonUpgradeAbility[1].interactable = false;
        }
    
        selectorPos();
        animatedPopUp();
    }

    void selectorPos() 
    {
        if (!isButtonAbilityClicked)
        {
            for (int i = 0; i < selectorPosObj.Length; i++)
            {
                if (buttonAbilityHighlightValue == i + 1)
                {
                    selector.transform.localPosition = selectorPosObj[i].transform.localPosition;
                    break;
                }
            }
        }
       
    }

    void eventListener() 
    {
        do
        {
            for (int j = 0; j < listAbilityButton.Length; j++)
            {
                int valueSelect = curValueSelect[j];

                listAbilityButton[j].onClick.AddListener(() => listButtonAbilityClick(valueSelect));

                EventTrigger eventTrigger = listAbilityButton[j].gameObject.AddComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback.AddListener((data) => { listButtonAbilityHighlighted(valueSelect); });
                eventTrigger.triggers.Add(entry);
            }

        } while (UISelectLevel.uiselectLevel.isGoingToStore);
       
    }

    void animatedPopUp() 
    {
        if (isAnimatedPopUp) 
        {
            upgradeAbilityObj.transform.localScale = Vector2.MoveTowards(upgradeAbilityObj.transform.localScale,
                new Vector2(1, 1), 20 * Time.deltaTime);
        }
        else 
        {
            upgradeAbilityObj.transform.localScale = Vector2.MoveTowards(upgradeAbilityObj.transform.localScale,
               new Vector2(0, 0), 20 * Time.deltaTime);
        } 
    }

    void listButtonAbilityClick(int value) 
    {
        buttonAbilityClickValue = value;
        isButtonAbilityClicked = true;
    }
    void listButtonAbilityHighlighted(int value) 
    {
        if (value > totalAbility) 
        {
            value = totalAbility;
        }

        buttonAbilityHighlightValue = value;
    }

    public void listAbilityButtonEnable() 
    {
        for (int j = 0; j < listAbilityButton.Length-2; j++)
        {
            listAbilityButton[j].interactable = true;
        }

        buttonBackToSelectLevel.interactable = true;
    }

    public void onClickBackToSelectAbility() 
    {
        isButtonAbilityClicked = false;
        listAbilityButtonEnable();
        
    }

    public void onClickUpgrade() 
    {
        if (buttonAbilityClickValue == 1) 
        {
            AbilityShadowUpgrade.abilityShadowUpgrade.onClickUpgradeShadow();
        }
        if (buttonAbilityClickValue == 2) 
        {
            AbilityInfinityStoneUpgrade.abilityInfinityStoneUpgrade.onClickUpgradeStone();
        }
        if (buttonAbilityClickValue == 3) 
        {
            AbilityMindControlUpgrade.abilityMindControlUpgrade.onClickUpgradeMindControl();
        }
    }

    public void onClickBackToLevel() 
    {
        UISelectLevel.uiselectLevel.isGoingToStore = false;
        selector.transform.localPosition = selectorPosObj[0].transform.localPosition;
        buttonAbilityHighlightValue = 0;
       
    }
}
