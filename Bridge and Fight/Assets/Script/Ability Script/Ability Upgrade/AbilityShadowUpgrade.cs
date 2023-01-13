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

    [Header("Info Shadow Upgrade Ability")]
    public int curShadowLevel;
    public int nextUpgradeLevel;
    public int curCostUpgrade;
    [SerializeField] bool isUpgraded;
    [SerializeField] int maxShadowLevel;
    [SerializeField] int yourBank;


    string abilityDesc = "the players will become ghost mode in a short time, when they're in ghost mode, players can cut through to all enemies and obstacles. But not if the players crash each other or cut thorugh the outer wall.";



    private void Awake()
    {
        abilityShadowUpgrade = this;
    }

    private void Start()
    {
        curShadowLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[2]);
        yourBank = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);
        nextUpgradeLevel = curShadowLevel + 1;
        
        
    }
    private void Update()
    {
        progressUp();
        saveDataUpShadow();
        
        


    }
    void progressUp() 
    {
        
       
        if(UIShop.uIShop.buttonAbilityClickValue == 1) 
        {
            textAbilityType.text = "Ability Type : Active";
            textDescAbility.text = abilityDesc;
            textUpgradeCost.text = curCostUpgrade.ToString();
            textAbilityName.text = "GHOST";
            if (curShadowLevel == 1)
            {
                textInfoAbilityUpgrade[0].enabled = true;
                textInfoAbilityUpgrade[1].enabled = true;
                textInfoAbilityUpgrade[0].text = "Cooldown  :  5s     +0s";
                textInfoAbilityUpgrade[1].text = "Duration     :  11s     +5s";

                imageAbilityCard.sprite = card[0];
                ImageAbilityIcon.sprite = icon[0];
               
                curCostUpgrade = 50;
                
                if (yourBank < curCostUpgrade) 
                {
                    
                    buttonUpgrade.interactable = false;
                }
                
                
            }
            if (curShadowLevel == 2)
            {
                textInfoAbilityUpgrade[0].enabled = true;
                textInfoAbilityUpgrade[1].enabled = true;
                textInfoAbilityUpgrade[0].text = "Cooldown  :  5s     +7s";
                textInfoAbilityUpgrade[1].text = "Duration     :  16s     +4s";

                imageAbilityCard.sprite = card[1];
                ImageAbilityIcon.sprite = icon[1];

                curCostUpgrade = 170;
                if (yourBank < curCostUpgrade)
                {
                   
                    buttonUpgrade.interactable = false;
                }
               
            }
            if (curShadowLevel == 3)
            {
                textInfoAbilityUpgrade[0].enabled = true;
                textInfoAbilityUpgrade[1].enabled = true;
                textInfoAbilityUpgrade[2].enabled = true;
                textInfoAbilityUpgrade[0].text = "Cooldown  :  12s";
                textInfoAbilityUpgrade[1].text = "Duration     :  20s";
                textInfoAbilityUpgrade[2].text = "Player now can pick the coin even ghost mode actived";

                imageAbilityCard.sprite = card[2];
                ImageAbilityIcon.sprite = icon[2];

                nextUpgradeLevel = 3;
                
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
        
        
        if (UIShop.uIShop.buttonAbilityClickValue == 1)
        {
            
            if (yourBank >= curCostUpgrade)
            {
                // Proses pengurangan sisa uang yang dimiliki
                yourBank -= curCostUpgrade;

                // Menyimpan data sisa uang yang dimiliki ke dalam PlayerPrefs
                PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[1], yourBank);

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
