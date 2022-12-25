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
    [SerializeField] TextMeshProUGUI textCurBank;
    [SerializeField] TextMeshProUGUI textStatusLevelShadow;
    [SerializeField] TextMeshProUGUI[] textDescAbility;

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
        textCurBank.text = "Your Money : " + yourBank +"$";
        textStatusLevelShadow.text = curShadowLevel.ToString();


    }
    void progressUp() 
    {
        if (!AbilityButtonList.abilityButton.isClickedToUpgradePopUp) 
        {
            isUpgraded = false;
        }
       
        if(AbilityButtonList.abilityButton.clickedValue == 1) 
        {
            textDescAbility[0].text = "Make you to become ghost mode within short time. [Active Ability]";
            textDescAbility[1].text = "II  Longer ghost activated timer";
            textDescAbility[2].text = "III More longer ghost timer when activated, and now you can still pick up the coin while you become ghost";
            if (curShadowLevel == 1)
            {
                
                curCostUpgrade = 50;
                
                if (yourBank < curCostUpgrade) 
                {
                    textInfoUpgrade.text = "Not enough money to upgrade. Next upgrade cost => "+curCostUpgrade + "$";
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
                    textInfoUpgrade.text = "Not enough money to upgrade. Next upgrade cost => " + curCostUpgrade + "$";
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
       
    }

    #region input Key/button

    #endregion
    public void onClickUpgradeShadow() 
    {
        
        
        if (AbilityButtonList.abilityButton.clickedValue == 1)
        {
            isUpgraded = true;
            if (yourBank >= curCostUpgrade)
            {
                // Proses pengurangan sisa uang yang dimiliki
                yourBank -= curCostUpgrade;

                // Menyimpan data sisa uang yang dimiliki ke dalam PlayerPrefs
                PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[1], yourBank);

                // Menyimpan data yang tersimpan di PlayerPrefs ke dalam file penyimpanan secara langsung
                PlayerPrefs.Save();
            }
            
            if (curShadowLevel < 3) 
            {
                curShadowLevel++;
            }
            
        }
    }
    
}
