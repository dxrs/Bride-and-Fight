using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityShadowUpgrade : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] Button buttonUpgrade;
    [SerializeField] TextMeshProUGUI textInfoUpgrade;

    [Header("Info Shadow Upgrade Ability")]
    public int curShadowLevel;
    public int nextUpgradeLevel;
    public int curCostUpgrade;
    [SerializeField] int maxShadowLevel;

    private void Start()
    {
        nextUpgradeLevel = curShadowLevel + 1;
        
    }
    private void Update()
    {
        if (AbilityButtonList.abilityButton.clickedValue == 1) 
        {
            textInfoUpgrade.text = "Upgrade Level " + curShadowLevel + " => " + nextUpgradeLevel + " Cost : " + curCostUpgrade + "$";
        }
        
    }
}
