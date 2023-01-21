using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityShadowUpgrade : MonoBehaviour
{
    public static AbilityShadowUpgrade abilityShadowUpgrade;

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

    [Header("Info Shadow Upgrade Ability")]
    public int curShadowLevel;
    public int curCostUpgrade;
    [SerializeField] int maxShadowLevel;
    [SerializeField] int yourBank;


    string abilityDesc = "players will become ghost mode in a short time, when they're in ghost mode, players can cut through to all enemies and obstacles. But not if the players crash each other or cut thorugh the outer wall.";

    int curLevel;



    private void Awake()
    {
        abilityShadowUpgrade = this;
    }

    private void Start()
    {
        curShadowLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[2]);
        //yourBank = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);
        curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);

        
        
    }
    private void Update()
    {
        progressUp();
        saveDataUpShadow();
        
        


    }
    void progressUp() 
    {

        if (curShadowLevel == 2) 
        {
            imageAbilityCard.sprite = card[1];
        }
        if (curShadowLevel == 3) 
        {
            imageAbilityCard.sprite = card[2];
        }
        if(UIShop.uIShop.buttonAbilityClickValue == 1) 
        {
            textAbilityType.text = "Ability Type : Active";
            textDescAbility.text = abilityDesc;
            textUpgradeCost.text = curCostUpgrade.ToString();
            textAbilityName.text = "GHOST v"+curShadowLevel;
            if (curShadowLevel == 1)
            {
               
                textInfoAbilityUpgrade[0].text = "Cooldown : 5s -> +0s";
                textInfoAbilityUpgrade[1].text = "Duration : 11s -> +5s";
                textInfoAbilityUpgrade[2].text = "";
                textInfoAbilityUpgrade[3].text = "";

                imageAbilityCard.sprite = card[0];
                ImageAbilityIcon.sprite = icon[0];
               
                curCostUpgrade = 10;

                /*
                if (yourBank < curCostUpgrade || curLevel<2) 
                {
                    textUpReq.text = "Upgrade Requirement : Complete Level 2";
                    buttonUpgrade.interactable = false;
                }
                if(yourBank>=curCostUpgrade && curLevel >= 2) 
                {
                    textUpReq.text = "";
                    buttonUpgrade.interactable = true;
                }
                if (yourBank >= curCostUpgrade && curLevel < 2)
                {
                    textUpReq.text = "Upgrade Requirement : Complete Level 2";
                    buttonUpgrade.interactable = false;
                }
                */
                if (UISelectLevel.uiselectLevel.bankValueData < curCostUpgrade)
                {
                    textUpReq.text = "not enough money";
                    buttonUpgrade.interactable = false;
                }
                if (UISelectLevel.uiselectLevel.bankValueData >= curCostUpgrade)
                {
                    textUpReq.text = "";
                    buttonUpgrade.interactable = true;
                }

            }
            if (curShadowLevel == 2)
            {
              
                textInfoAbilityUpgrade[0].text = "Cooldown : 5s -> +7s";
                textInfoAbilityUpgrade[1].text = "Duration : 16s -> +4s";
                textInfoAbilityUpgrade[2].text = "Player now can pick the coin even ghost mode actived";
                textInfoAbilityUpgrade[3].text = "";

                ImageAbilityIcon.sprite = icon[1];

                curCostUpgrade = 450;

                /*
                if (yourBank < curCostUpgrade || curLevel < 3)
                {
                    textUpReq.text = "Upgrade Requirement : Complete Level 3";
                    buttonUpgrade.interactable = false;
                }

                if (yourBank >= curCostUpgrade && curLevel >= 3)
                {
                    textUpReq.text = "";
                    buttonUpgrade.interactable = true;
                }
                if (yourBank >= curCostUpgrade && curLevel < 3)
                {
                    textUpReq.text = "Upgrade Requirement : Complete Level 3";
                    buttonUpgrade.interactable = false;
                }
                */

                if (UISelectLevel.uiselectLevel.bankValueData < curCostUpgrade)
                {
                    textUpReq.text = "not enough money";
                    buttonUpgrade.interactable = false;
                }
                if (UISelectLevel.uiselectLevel.bankValueData >= curCostUpgrade)
                {
                    textUpReq.text = "";
                    buttonUpgrade.interactable = true;
                }

            }
            if (curShadowLevel == 3)
            {

                objectCoinImage.SetActive(false);

                textUpReq.text = "Max Level";

                for (int j = 0; j < textInfoAbilityUpgrade.Length; j++) 
                {
                    textInfoAbilityUpgrade[j].enabled = true;
                }
              
                textInfoAbilityUpgrade[0].text = "Cooldown : 12s";
                textInfoAbilityUpgrade[1].text = "Duration : 20s";
                textInfoAbilityUpgrade[2].text = "";
                textInfoAbilityUpgrade[3].text = "";


                ImageAbilityIcon.sprite = icon[2];

                
                buttonUpgrade.interactable = false;
            }
        }
       
    }
    void saveDataUpShadow() 
    {
        if (curShadowLevel > 1) 
        {
            PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[2], curShadowLevel);
        }
       
    }

    #region input Key/button

    #endregion
    public void onClickUpgradeShadow() 
    {

        
        {
            if (UIShop.uIShop.buttonAbilityClickValue == 1)
            {

                if (UISelectLevel.uiselectLevel.bankValueData >= curCostUpgrade)
                {
                    // Proses pengurangan sisa uang yang dimiliki
                    UISelectLevel.uiselectLevel.bankValueData -= curCostUpgrade;

                    // Menyimpan data sisa uang yang dimiliki ke dalam PlayerPrefs
                    PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[1], UISelectLevel.uiselectLevel.bankValueData);

                    // Menyimpan data yang tersimpan di PlayerPrefs ke dalam file penyimpanan secara langsung
                    PlayerPrefs.Save();
                }

                if (curShadowLevel < 3)
                {
                    curShadowLevel++;
                }


            }
        }
       
    }
    
}
