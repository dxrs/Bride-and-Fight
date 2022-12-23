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
    [SerializeField] GameObject abilityShowUp;
    [SerializeField] Button buttonUp;
    [SerializeField] Button buttonStore;
    [SerializeField] TextMeshProUGUI textMoney;

    [Header("List DBMS Value")]
    [SerializeField] int coinData;
    public int curBank;


    private void Awake()
    {
        uISelectLevelManager = this;
    }

    private void Start()
    {
        coinData = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[0]);
        //curBank = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);
        
    }
    private void Update()
    {
        textMoney.text = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]).ToString();
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
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (AbilityButtonList.abilityButton.isClicked) 
            {
                AbilityButtonList.abilityButton.isClicked = false;
            }
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
