using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AbilityInfinityStoneUpgrade : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] Button buttonUpgrade;
    [SerializeField] TextMeshProUGUI textInfoUpgrade;

    [Header("Info Shadow Upgrade Ability")]
    public int curStoneLevel;
    public int nextUpgradeLevel;
    public int curCostUpgrade;
    [SerializeField] int maxStoneLevel;

    private void Start()
    {
        nextUpgradeLevel = curStoneLevel + 1;

    }
    private void Update()
    {
        if (AbilityButtonList.abilityButton.clickedValue == 2) 
        {
            textInfoUpgrade.text = "Upgrade Level " + curStoneLevel + " => " + nextUpgradeLevel + " Cost : " + curCostUpgrade + "$";
        }
       
    }
}
