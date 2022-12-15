using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityHealBlastUpgrade : MonoBehaviour
{
    public static AbilityHealBlastUpgrade abilityHealBlastUpgrade;

    [Header("Other")]
    [SerializeField] Button abilityButtonClick;


    private void Awake()
    {
        abilityHealBlastUpgrade = this;
    }
    private void Update()
    {
        if (UpgradeSystem.upgradeSystem.totalCurAbility < 3 || AbilityButtonList.abilityButton.isClicked) 
        {
            abilityButtonClick.interactable = false;
        }else if (UpgradeSystem.upgradeSystem.totalCurAbility >= 3 && !AbilityButtonList.abilityButton.isClicked) 
        {
            abilityButtonClick.interactable = true;
        }
    }
}
