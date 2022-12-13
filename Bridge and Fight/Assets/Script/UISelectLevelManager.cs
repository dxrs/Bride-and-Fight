using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UISelectLevelManager : MonoBehaviour
{
    public static UISelectLevelManager uISelectLevelManager;


    [SerializeField] Button buttonBackToSelectLevel;
    //[SerializeField] Button buttonBackToStore;
    [SerializeField] GameObject abilityShowUp;

    [Header("List DBMS Value")]
    [SerializeField] int coinData;
    [SerializeField] int curBank;


    private void Awake()
    {
        uISelectLevelManager = this;
    }

    private void Start()
    {
        coinData = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[0]);
        curBank = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);
        
    }
    private void Update()
    {
        if (AbilityButtonList.abilityButton.isClicked) 
        {
            buttonBackToSelectLevel.interactable = false;
            abilityShowUp.SetActive(true);
        }
        else 
        {
            buttonBackToSelectLevel.interactable = true;
            abilityShowUp.SetActive(false);
        }
    }
    public void onClickBackToStore() 
    {
        AbilityButtonList.abilityButton.isClicked = false;
    }






}
