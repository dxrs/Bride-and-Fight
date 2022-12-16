using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AbilityInfinityStoneUpgrade : MonoBehaviour
{
    public static AbilityInfinityStoneUpgrade abilityInfinityStoneUpgrade;

    [Header("Other")]
    [SerializeField] Button buttonUpgrade;
    [SerializeField] TextMeshProUGUI textInfoUpgrade;
    [SerializeField] TextMeshProUGUI textCurBank;
    [SerializeField] Image[] imgStatuLevelAbility;

    [Header("Info Shadow Upgrade Ability")]
    public int curStoneLevel;
    public int nextUpgradeLevel;
    public int curCostUpgrade;
    [SerializeField] bool isUpgraded;
    [SerializeField] int maxStoneLevel;
    [SerializeField] int yourBank;

    private void Awake()
    {
        abilityInfinityStoneUpgrade = this;
    }
    private void Start()
    {
        curStoneLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[3]);
        yourBank = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);
        nextUpgradeLevel = curStoneLevel + 1;

    }
    private void Update()
    {
        if (AbilityButtonList.abilityButton.isClicked)
        {
            if (AbilityButtonList.abilityButton.clickedValue == 2 && curStoneLevel == 3)
            {
                buttonUpgrade.interactable = false;
            }
        }

        progressUp();
        saveDataUpStone();
        textCurBank.text = "Your Money : " + yourBank + "$";

    }
    void progressUp() 
    {
        if (!AbilityButtonList.abilityButton.isClicked) 
        {
            isUpgraded = false;
        }
        switch (curStoneLevel) 
        {
            case 1:
                imgStatuLevelAbility[0].enabled = true;
                break;
            case 2:
                imgStatuLevelAbility[0].enabled = true;
                imgStatuLevelAbility[1].enabled = true;
                break;
            case 3:
                imgStatuLevelAbility[0].enabled = true;
                imgStatuLevelAbility[1].enabled = true;
                imgStatuLevelAbility[2].enabled = true;
                break;
        }
        if (AbilityButtonList.abilityButton.clickedValue == 2) 
        {
            if (curStoneLevel == 1)
            {
                curCostUpgrade = 80;
                if (yourBank < curCostUpgrade) 
                {
                    textInfoUpgrade.text = "Not enough money to upgrade. Next upgrade cost => " + curCostUpgrade + "$";
                    buttonUpgrade.interactable = false;
                }
                if (yourBank >= curCostUpgrade) 
                {
                    textInfoUpgrade.text = "Upgrade Level " + curStoneLevel + " => " + nextUpgradeLevel + " Cost : " + curCostUpgrade + "$";
                }
            }
            if (curStoneLevel == 2) 
            {
                curCostUpgrade = 280;
                if (yourBank < curCostUpgrade)
                {
                    textInfoUpgrade.text = "Not enough money to upgrade. Next upgrade cost => " + curCostUpgrade +"$";
                    buttonUpgrade.interactable = false;
                }
                if (yourBank >= curCostUpgrade)
                {
                    textInfoUpgrade.text = "Upgrade Level " + curStoneLevel + " => " + nextUpgradeLevel + " Cost : " + curCostUpgrade + "$";
                }
            }
            if (curStoneLevel == 3) 
            {
                nextUpgradeLevel = 3;
                textInfoUpgrade.text = "Level Maxed";
                buttonUpgrade.interactable = false;
            }
        }
    }
    void saveDataUpStone() 
    {
        if (curStoneLevel > 1) 
        {
            PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[3], curStoneLevel);
        }
    }
    public void onClickUpgradeStone() 
    {
        if (AbilityButtonList.abilityButton.clickedValue == 2)
        {
            isUpgraded = true;
            if (yourBank >= curCostUpgrade) 
            {
                yourBank -= curCostUpgrade;
                PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[1], yourBank);

                // Menyimpan data yang tersimpan di PlayerPrefs ke dalam file penyimpanan secara langsung
                PlayerPrefs.Save();
            }
            if (curStoneLevel < 3)
            {
                curStoneLevel++;
            }

        }
    }
}
