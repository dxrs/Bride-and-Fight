using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityMindControlUpgrade : MonoBehaviour
{
    public static AbilityMindControlUpgrade abilityMindControlUpgrade;

    [Header("Other")]
    [SerializeField] Button buttonUpgrade;
    [SerializeField] Button buttonCardAbility;

    [SerializeField] Image imageAbilityCard;
    [SerializeField] Image ImageAbilityIcon;

    [SerializeField] Sprite[] card;
    [SerializeField] Sprite[] icon;

    [SerializeField] TextMeshProUGUI textAbilityType;
    [SerializeField] TextMeshProUGUI[] textInfoAbilityUpgrade;
    [SerializeField] TextMeshProUGUI textDescAbility;
    [SerializeField] TextMeshProUGUI textUpgradeCost;
    [SerializeField] TextMeshProUGUI textAbilityName;
    [SerializeField] TextMeshProUGUI textUpReq;

    [SerializeField] GameObject objectCoinImage;

    [Header("Info Mind Control Upgrade Ability")]
    public int curMindControlLevel;
    public int nextUpgradeLevel;
    public int curCostUpgrade;
    [SerializeField] int maxStoneLevel;
    [SerializeField] int yourBank;

    int curLevel;
    int curTotalAbility;

    string abilityDesc = "one of the players will have a diamond ring, and when the item is summoned it will produce several diamonds, when the enemy touches the diamond then the enemy will become our friend we called friendly bot and seek and destroy other enemies.";


    private void Awake()
    {
        abilityMindControlUpgrade = this;
    }

    private void Start()
    {
        curMindControlLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[5]);
        yourBank = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);
        curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);
        curTotalAbility= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[4]);

        
    }

    private void Update()
    {

        if (curLevel == 2) 
        {
            curTotalAbility = 3;
            PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[4], curTotalAbility);
        }
        if (curTotalAbility >= 3 && curMindControlLevel == 1)
        {
            imageAbilityCard.sprite = card[0];
        }
        if (curTotalAbility>=3 && UISelectLevel.uiselectLevel.isGoingToStore && !UIShop.uIShop.isButtonAbilityClicked) 
        {
            buttonCardAbility.interactable = true;
        }

        if(!UISelectLevel.uiselectLevel.isGoingToStore ||UIShop.uIShop.isButtonAbilityClicked ) 
        {
            buttonCardAbility.interactable = false;
        }

        progressUp();
        saveDataUpMindControl();
    }

    void progressUp() 
    {
        if (UIShop.uIShop.buttonAbilityClickValue == 3) 
        {
            textAbilityType.text = "Ability Type : Active";
            textDescAbility.text = abilityDesc;
            textUpgradeCost.text = curCostUpgrade.ToString();
            textAbilityName.text = "HYPNOTIC";

            if (curMindControlLevel == 1) 
            {
                textInfoAbilityUpgrade[0].enabled = true;
                textInfoAbilityUpgrade[1].enabled = true;

                textInfoAbilityUpgrade[0].text = "Max Bot Health :  1hp     +1hp";
                textInfoAbilityUpgrade[1].text = "Duration :  15     +2";

                imageAbilityCard.sprite = card[0];
                ImageAbilityIcon.sprite = icon[0];

              

                curCostUpgrade = 500;
                if (yourBank < curCostUpgrade || curLevel < 13)
                {
                    textUpReq.text = "Requirement : Complete Level 13";
                    buttonUpgrade.interactable = false;
                }
                if (yourBank >= curCostUpgrade && curLevel >= 13)
                {
                    textUpReq.text = "";
                    buttonUpgrade.interactable = true;
                }
                if (yourBank >= curCostUpgrade && curLevel < 13)
                {
                    textUpReq.text = "Requirement : Complete Level 13";
                    buttonUpgrade.interactable = false;
                }
            }
            if (curMindControlLevel == 2) 
            {
                for (int j = 0; j < textInfoAbilityUpgrade.Length; j++)
                {
                    textInfoAbilityUpgrade[j].enabled = true;
                }

                textInfoAbilityUpgrade[0].text = "Max Bot Health :  2hp";
                textInfoAbilityUpgrade[1].text = "Duration :  17     +1";
                textInfoAbilityUpgrade[2].text = "Diamond ring will moving random through the arena";
                
                imageAbilityCard.sprite = card[1];
                ImageAbilityIcon.sprite = icon[1];

               

                curCostUpgrade = 850;
                if (yourBank < curCostUpgrade || curLevel < 20)
                {
                    textUpReq.text = "Requirement : Complete Level 20";
                    buttonUpgrade.interactable = false;
                }
                if (yourBank >= curCostUpgrade && curLevel >= 20)
                {
                    textUpReq.text = "";
                    buttonUpgrade.interactable = true;
                }
                if (yourBank >= curCostUpgrade && curLevel < 20)
                {
                    textUpReq.text = "Requirement : Complete Level 20";
                    buttonUpgrade.interactable = false;
                }
            }
            if (curMindControlLevel == 3) 
            {
                objectCoinImage.SetActive(false);

                textUpReq.text = "Max Level";
                for (int j = 0; j < textInfoAbilityUpgrade.Length; j++)
                {
                    textInfoAbilityUpgrade[j].enabled = true;
                }

                textInfoAbilityUpgrade[0].text = "Max Bot Health :  2hp";
                textInfoAbilityUpgrade[1].text = "Duration :  18";
                textInfoAbilityUpgrade[2].text = "When bot hit enemies adding 2hp player's health";

                imageAbilityCard.sprite = card[2];
                ImageAbilityIcon.sprite = icon[2];

                buttonUpgrade.interactable = false;
            }
        }

    }
    void saveDataUpMindControl() 
    {
        if (curMindControlLevel > 1)
        {
            PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[5], curMindControlLevel);
        }
    }
    public void onClickUpgradeMindControl() 
    {
        if (UIShop.uIShop.buttonAbilityClickValue == 3)
        {

            if (yourBank >= curCostUpgrade)
            {
                yourBank -= curCostUpgrade;
                PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[1], yourBank);

                // Menyimpan data yang tersimpan di PlayerPrefs ke dalam file penyimpanan secara langsung
                PlayerPrefs.Save();
            }
            if (curMindControlLevel < 3)
            {
                curMindControlLevel++;
            }

        }
    }
}