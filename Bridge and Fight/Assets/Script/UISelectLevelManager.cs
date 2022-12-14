using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class UISelectLevelManager : MonoBehaviour
{
    public static UISelectLevelManager uISelectLevelManager;


    [SerializeField] Button buttonBackToSelectLevel;
    //[SerializeField] Button buttonBackToStore;
    [SerializeField] GameObject abilityShowUp;
    [SerializeField] Button buttonUp;
    [SerializeField] TextMeshProUGUI textMoney;

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
        textMoney.text = curBank.ToString();
        if (AbilityButtonList.abilityButton.isClicked) 
        {
            buttonBackToSelectLevel.interactable = false;
            abilityShowUp.SetActive(true);
        }
        else 
        {
            buttonBackToSelectLevel.interactable = true;
            buttonUp.interactable = true;
            abilityShowUp.SetActive(false);
        }
    }
    public void onClickBackToStore() 
    {
        AbilityButtonList.abilityButton.isClicked = false;
    }
    public void onClickPlay() 
    {
        SceneManager.LoadScene("Scene firza");
    }






}
