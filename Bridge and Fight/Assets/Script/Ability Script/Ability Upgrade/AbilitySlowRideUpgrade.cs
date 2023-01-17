using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilitySlowRideUpgrade : MonoBehaviour
{
    public static AbilitySlowRideUpgrade abilitySlowRideUpgrade;


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

    [Header("Info Infinity Stone Upgrade Ability")]
    public int curSlowRideLevel;
    public int curCostUpgrade;
    [SerializeField] int maxSlowRideLevel;
    [SerializeField] int yourBank;

    string abilityDesc = "when the enemy hits the player, the player will spawn a big explosion, when the enemy touches the particles of the explosion, their movement will become slow in a short time.";

    int curLevel;
    int curTotalAbility;

    private void Awake()
    {
        abilitySlowRideUpgrade = this;
    }

    private void Start()
    {
        curSlowRideLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[11]);
        yourBank = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);
        curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);
        curTotalAbility = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[4]);
    }

    private void Update()
    {
        if (curLevel == 3)
        {
            curTotalAbility = 4;
            PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[4], curTotalAbility);
        }
        if (curTotalAbility >= 4 && curSlowRideLevel == 1)
        {
            imageAbilityCard.sprite = card[0];
        }
        if (curTotalAbility >= 4 && UISelectLevel.uiselectLevel.isGoingToStore && !UIShop.uIShop.isButtonAbilityClicked)
        {
            buttonCardAbility.interactable = true;
        }

        if (!UISelectLevel.uiselectLevel.isGoingToStore || UIShop.uIShop.isButtonAbilityClicked)
        {
            buttonCardAbility.interactable = false;
        }
    }

    void progressUp() 
    {
        if (UIShop.uIShop.buttonAbilityClickValue == 4)
        {
            textAbilityType.text = "Ability Type : Passive";
            textDescAbility.text = abilityDesc;
            textUpgradeCost.text = curCostUpgrade.ToString();
            textAbilityName.text = "SLOW RIDE";
            if (curSlowRideLevel == 1)
            {

                textInfoAbilityUpgrade[0].enabled = true;
                textInfoAbilityUpgrade[1].enabled = true;

                textInfoAbilityUpgrade[0].text = "Blast Speed : 4s -> +3s";
                textInfoAbilityUpgrade[1].text = "Max Blast Scale : 5 -> +5";

                imageAbilityCard.sprite = card[0];
                ImageAbilityIcon.sprite = icon[0];

                curCostUpgrade = 450;

                /*
                if (yourBank < curCostUpgrade || curLevel < 6)
                {
                    textUpReq.text = "Requirement : Complete Level 6";
                    buttonUpgrade.interactable = false;
                }
                if (yourBank >= curCostUpgrade && curLevel >= 6)
                {
                    textUpReq.text = "";
                    buttonUpgrade.interactable = true;
                }
                if (yourBank >= curCostUpgrade && curLevel < 6)
                {
                    textUpReq.text = "Requirement : Complete Level 6";
                    buttonUpgrade.interactable = false;
                }
                */

                if (yourBank < curCostUpgrade)
                {
                    textUpReq.text = "not enough money";
                    buttonUpgrade.interactable = false;
                }
                if (yourBank >= curCostUpgrade) 
                {
                    buttonUpgrade.interactable = false;
                }

            }
            if (curSlowRideLevel == 2)
            {
                textInfoAbilityUpgrade[0].enabled = true;
                textInfoAbilityUpgrade[1].enabled = true;
                textInfoAbilityUpgrade[0].text = "Blast Speed : 7s -> +3s";
                textInfoAbilityUpgrade[1].text = "Max Blast Scale : 10 -> +2";

                imageAbilityCard.sprite = card[1];
                ImageAbilityIcon.sprite = icon[1];

                curCostUpgrade = 780;
                /*
                if (yourBank < curCostUpgrade || curLevel < 15)
                {
                    textUpReq.text = "Upgrade Requirement : Complete Level 15";
                    buttonUpgrade.interactable = false;
                }

                if (yourBank >= curCostUpgrade && curLevel >= 15)
                {
                    textUpReq.text = "";
                    buttonUpgrade.interactable = true;
                }
                if (yourBank >= curCostUpgrade && curLevel < 15)
                {
                    textUpReq.text = "Upgrade Requirement : Complete Level 15";
                    buttonUpgrade.interactable = false;
                }
                */
                if (yourBank < curCostUpgrade)
                {
                    textUpReq.text = "not enough money";
                    buttonUpgrade.interactable = false;
                }
                if (yourBank >= curCostUpgrade)
                {
                    buttonUpgrade.interactable = false;
                }

            }
            if (curSlowRideLevel == 3)
            {

                objectCoinImage.SetActive(false);

                textUpReq.text = "Max Level";

                for (int j = 0; j < textInfoAbilityUpgrade.Length; j++)
                {
                    textInfoAbilityUpgrade[j].enabled = true;
                }

                textInfoAbilityUpgrade[0].text = "Blast Speed : 10s";
                textInfoAbilityUpgrade[1].text = "Max Blast Scale : 12";


                imageAbilityCard.sprite = card[2];
                ImageAbilityIcon.sprite = icon[2];


                buttonUpgrade.interactable = false;
            }
        }
    }

    void saveDataUpSlowRide() 
    {
        if (curSlowRideLevel > 1)
        {
            PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[11], curSlowRideLevel);
        }
    }

    public void onClickUpgradeSlowRide() 
    {
        if (UIShop.uIShop.buttonAbilityClickValue == 4)
        {

            if (yourBank >= curCostUpgrade)
            {
                yourBank -= curCostUpgrade;
                PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[1], yourBank);

                // Menyimpan data yang tersimpan di PlayerPrefs ke dalam file penyimpanan secara langsung
                PlayerPrefs.Save();
            }
            if (curSlowRideLevel < 3)
            {
                curSlowRideLevel++;
            }

        }
    }
}
