using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSystem : MonoBehaviour
{
    public static UpgradeSystem upgradeSystem;

    [SerializeField] string[] abilityName;
    [SerializeField] TextMeshProUGUI textAbilityName;

    
    private void Awake()
    {
        upgradeSystem = this;
    }

    private void Update()
    {
        if (AbilityButtonList.abilityButton.isClicked) 
        {
            for(int j = 0; j < abilityName.Length; j++) 
            {
                if ((j+1) == AbilityButtonList.abilityButton.clickedValue)
                {
                    textAbilityName.text = abilityName[j];
                    break;
                }
            }
        }
    }
}