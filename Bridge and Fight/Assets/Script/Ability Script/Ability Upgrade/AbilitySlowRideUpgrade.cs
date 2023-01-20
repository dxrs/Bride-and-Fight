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
        progressUp();
        saveDataUpSlowRide();
    }

    void progressUp() 
    {
        if (curSlowRideLevel == 2) 
        {

            imageAbilityCard.sprite = card[1];
        }
        if (curSlowRideLevel == 3) 
        {
            imageAbilityCard.sprite = card[2];
        }
        if (UIShop.uIShop.buttonAbilityClickValue == 4)
        {
            textAbilityType.text = "Ability Type : Passive";
            textDescAbility.text = abilityDesc;
            textUpgradeCost.text = curCostUpgrade.ToString();
            textAbilityName.text = "SLOW RIDE v"+curSlowRideLevel;
            if (curSlowRideLevel == 1)
            {

               
                textInfoAbilityUpgrade[0].text = "Blast Speed : 4s -> +3s";
                textInfoAbilityUpgrade[1].text = "Max Blast Scale : 5 -> +5";
                textInfoAbilityUpgrade[2].text = "when enemy get hit by low ball, then will add some health to each players when their health is low";
                textInfoAbilityUpgrade[3].text = "";
                imageAbilityCard.sprite = card[0];
                ImageAbilityIcon.sprite = icon[0];

                curCostUpgrade = 100;

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
                    textUpReq.text = "";
                    buttonUpgrade.interactable = true;
                }

            }
            if (curSlowRideLevel == 2)
            {
            
                textInfoAbilityUpgrade[0].text = "Blast Speed : 7s -> +3s";
                textInfoAbilityUpgrade[1].text = "Max Blast Scale : 10 -> +2";
                textInfoAbilityUpgrade[2].text = "";
                textInfoAbilityUpgrade[3].text = "";
                ImageAbilityIcon.sprite = icon[1];

                curCostUpgrade = 550;
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
                    textUpReq.text = "";
                    buttonUpgrade.interactable = true;
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
                textInfoAbilityUpgrade[2].text = "";
                textInfoAbilityUpgrade[3].text = "";

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
