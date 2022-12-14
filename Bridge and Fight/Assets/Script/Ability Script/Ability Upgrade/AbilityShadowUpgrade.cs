using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityShadowUpgrade : MonoBehaviour
{
    public static AbilityShadowUpgrade abilityShadowUpgrade;

    [Header("Other")]
    [SerializeField] Button buttonUpgrade;
    [SerializeField] TextMeshProUGUI textInfoUpgrade;

    [Header("Info Shadow Upgrade Ability")]
    public int curShadowLevel;
    public int nextUpgradeLevel;
    public int curCostUpgrade;
    [SerializeField] bool isUpgraded;
    [SerializeField] int maxShadowLevel;
    [SerializeField] int yourBank;

    private void Awake()
    {
        abilityShadowUpgrade = this;
    }

    private void Start()
    {
        curShadowLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[2]);
        yourBank = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);
        nextUpgradeLevel = curShadowLevel + 1;
        
    }
    private void Update()
    {
        progressUp();
        saveDataUpShadow();
        

    }
    void progressUp() 
    {
        if (!AbilityButtonList.abilityButton.isClicked) 
        {
            isUpgraded = false;
        }
        if(AbilityButtonList.abilityButton.clickedValue == 1) 
        {
            if (curShadowLevel == 1)
            {
                curCostUpgrade = 50;
               
                if (yourBank < curCostUpgrade) 
                {
                    textInfoUpgrade.text = "Not enough money to upgrade";
                    buttonUpgrade.interactable = false;
                }
                if (yourBank >=curCostUpgrade) 
                {
                    textInfoUpgrade.text = "Upgrade Level " + curShadowLevel + " => " + nextUpgradeLevel + " Cost : " + curCostUpgrade + "$";
                }
                
            }
            if (curShadowLevel == 2)
            {
                curCostUpgrade = 170;
                if (yourBank < curCostUpgrade)
                {
                    textInfoUpgrade.text = "Not enough money to upgrade";
                    buttonUpgrade.interactable = false;
                }
                if (yourBank >= curCostUpgrade)
                {
                    textInfoUpgrade.text = "Upgrade Level " + curShadowLevel + " => " + nextUpgradeLevel + " Cost : " + curCostUpgrade + "$";
                }
            }
            if (curShadowLevel == 3) 
            {
                nextUpgradeLevel = 3;
                textInfoUpgrade.text = "Level Maxed";
                buttonUpgrade.interactable = false;
            }
        }
       
    }
    void saveDataUpShadow() 
    {
        if (curShadowLevel > 1) 
        {
            PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[2], curShadowLevel);
        }
        if (isUpgraded) 
        {
            PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[1], yourBank);
        }
    }
    public void onClickUpgradeShadow() 
    {
        
        
        if (AbilityButtonList.abilityButton.clickedValue == 1) 
        {
            isUpgraded = true;
            if (isUpgraded) 
            {
                yourBank -= curCostUpgrade;
            }
            if (curShadowLevel < 3) 
            {
                curShadowLevel++;
            }
            
        }
    }
    
}
