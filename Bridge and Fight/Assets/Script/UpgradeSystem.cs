using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSystem : MonoBehaviour
{
    public static UpgradeSystem upgradeSystem;

    [SerializeField] string[] abilityName;
    [SerializeField] string[] abilitydDesc;
    [SerializeField] Sprite[] abilityIcon;
    [SerializeField] Image abilityImage;
    [SerializeField] TextMeshProUGUI textAbilityName;
    [SerializeField] TextMeshProUGUI textAbilityDesc;

    public int totalCurAbility;
    private void Awake()
    {
        upgradeSystem = this;
    }
    private void Start()
    {
        totalCurAbility = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[4]);
    }
    private void Update()
    {
        if (AbilityButtonList.abilityButton.isClickedToUpgradePopUp) 
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

        imagePerAbility();
    }

    void imagePerAbility() 
    {
        if (AbilityButtonList.abilityButton.isClickedToUpgradePopUp)
        {
            for (int i = 0; i < abilityIcon.Length; i++)
            {
                if (AbilityButtonList.abilityButton.clickedValue == i+1)
                {
                    abilityImage.sprite = abilityIcon[i];
                    break;
                }
            }
        }
    }
}
