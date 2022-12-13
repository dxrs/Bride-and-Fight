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

    [Header("Info Shadow Upgrade Ability")]
    public int curStoneLevel;
    public int nextUpgradeLevel;
    public int curCostUpgrade;
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
        if (AbilityButtonList.abilityButton.clickedValue == 2) 
        {
            textInfoUpgrade.text = "Upgrade Level " + curStoneLevel + " => " + nextUpgradeLevel + " Cost : " + curCostUpgrade + "$";
        }
       
    }
    public void onClickUpgradeStone() 
    {
        curStoneLevel++;
    }
}
