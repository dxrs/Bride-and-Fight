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
    public int curStoneLevel;
    public int curCostUpgrade;
    [SerializeField] int maxStoneLevel;
    [SerializeField] int yourBank;

    string abilityDesc = "players will have a stone that protect from enemies, and each player will have his own stone, the stone will be destroyed when the enemy hits it, and will reappear within the specified time";

    int curLevel;

    private void Awake()
    {
        abilityInfinityStoneUpgrade = this;
    }
    private void Start()
    {
        curStoneLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[3]);
        yourBank = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);
        curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);
        

    }
    private void Update()
    {
       

        progressUp();
        saveDataUpStone();
   

    }
    void progressUp() 
    {

        if (curStoneLevel == 2)
        {

            imageAbilityCard.sprite = card[1];
        }
        if (curStoneLevel == 3) 
        {
            imageAbilityCard.sprite = card[2];
        }
        
        if (UIShop.uIShop.buttonAbilityClickValue == 2) 
        {
            textAbilityType.text = "Ability Type : Passive";
            textDescAbility.text = abilityDesc;
            textUpgradeCost.text = curCostUpgrade.ToString();
            textAbilityName.text = "INFINITY STONE v"+curStoneLevel;
            if (curStoneLevel == 1)
            {


                textInfoAbilityUpgrade[0].text = "Stone Respawn : 10s -> +6.5s";
                textInfoAbilityUpgrade[1].text = "Max Stone : 2 -> +2";
                textInfoAbilityUpgrade[2].text = "";
                textInfoAbilityUpgrade[3].text = "";

                imageAbilityCard.sprite = card[0];
                ImageAbilityIcon.sprite = icon[0];

                curCostUpgrade = 90;

                /*
                if (yourBank < curCostUpgrade || curLevel < 4)
                {
                    textUpReq.text = "Upgrade Requirement : Complete Level 4";
                    buttonUpgrade.interactable = false;
                }
                if (yourBank >= curCostUpgrade && curLevel >= 4)
                {
                    textUpReq.text = "";
                    buttonUpgrade.interactable = true;
                }
                if (yourBank >= curCostUpgrade && curLevel < 4)
                {
                    textUpReq.text = "Upgrade Requirement : Complete Level 4";
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
            if (curStoneLevel == 2) 
            {
              
                textInfoAbilityUpgrade[0].text = "Stone Respawn : 16.5s -> +10s";
                textInfoAbilityUpgrade[1].text = "Max Stone : 4 -> +2";
                textInfoAbilityUpgrade[2].text = "";
                textInfoAbilityUpgrade[3].text = "";

                ImageAbilityIcon.sprite = icon[1];

                curCostUpgrade = 500;
                /*
                if (yourBank < curCostUpgrade || curLevel < 9)
                {
                    textUpReq.text = "Upgrade Requirement : Complete Level 9";
                    buttonUpgrade.interactable = false;
                }

                if (yourBank >= curCostUpgrade && curLevel >= 9)
                {
                    textUpReq.text = "";
                    buttonUpgrade.interactable = true;
                }
                if (yourBank >= curCostUpgrade && curLevel < 9)
                {
                    textUpReq.text = "Upgrade Requirement : Complete Level 9";
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
            if (curStoneLevel == 3) 
            {

                objectCoinImage.SetActive(false);

                textUpReq.text = "Max Level";

                for (int j = 0; j < textInfoAbilityUpgrade.Length; j++)
                {
                    textInfoAbilityUpgrade[j].enabled = true;
                }

                textInfoAbilityUpgrade[0].text = "Stone Respawn : 28.5s";
                textInfoAbilityUpgrade[1].text = "Max Stone : 8";
                textInfoAbilityUpgrade[2].text = "";
                textInfoAbilityUpgrade[3].text = "";


                ImageAbilityIcon.sprite = icon[2];

        
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
        if (UIShop.uIShop.buttonAbilityClickValue == 2)
        {
           
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
