using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class UISelectLevelManager : MonoBehaviour
{
    public static UISelectLevelManager uISelectLevelManager;

    public bool isGoingToStore;
   

    [Header("Boolean Controller")]
    public bool keyButtonPressedBack;
    public bool keyButtonPressedEnter;

    [Header("Alfa Store")]
    [SerializeField] Button buttonBackToSelectLevel;
    [SerializeField] GameObject abilityShowUp;
    [SerializeField] GameObject alfaStore;
    [SerializeField] GameObject storeStock;
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
        shoppingGuys();
        storeInputController();
        
    }

    #region at the store
    void shoppingGuys() 
    {
        textMoney.text = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]).ToString();
        if (AbilityButtonList.abilityButton.isClickedToUpgradePopUp)
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
       
        
       
        if (alfaStore.transform.localPosition.x == 0) 
        {
            storeStock.SetActive(true);
        }
        if (alfaStore.transform.localPosition.x == 2140) 
        {
            storeStock.SetActive(false);
        }

        goingToStore();
    }

    void goingToStore() 
    {
        if (isGoingToStore || SelectPlanet.selectPlanet.isPlanetClicked) 
        {
            buttonStore.interactable = false;
        }
        if (!isGoingToStore && !SelectPlanet.selectPlanet.isPlanetClicked) 
        {
            buttonStore.interactable = true;
        }
        if (isGoingToStore) 
        {
            
            alfaStore.transform.localPosition = Vector2.MoveTowards(alfaStore.transform.localPosition,
                new Vector2(0, 0), 6000 * Time.deltaTime);
        }
        else 
        {
            
            alfaStore.transform.localPosition = Vector2.MoveTowards(alfaStore.transform.localPosition,
                    new Vector2(2140, 0), 6000 * Time.deltaTime);
        }
       
        
    }

    void storeInputController()
    {



        buttonBack();
        buttonEnter();
        inputToStore();

    }

    void buttonBack() //untuk semua button back (esc/buttonB) di select level 
    {
        if (Input.GetButton("Bbutton") || Input.GetKeyDown(KeyCode.Escape))
        {
            if (!keyButtonPressedBack)
            {
                keyButtonPressedBack = true;
                if (AbilityButtonList.abilityButton.isClickedToUpgradePopUp)
                {
                    AbilityButtonList.abilityButton.isClickedToUpgradePopUp = false;
                }
                else if (!AbilityButtonList.abilityButton.isClickedToUpgradePopUp)
                {
                    isGoingToStore = false;


                }
                if (SelectPlanet.selectPlanet.isPlanetClicked) 
                {
                    SelectPlanet.selectPlanet.isPlanetClicked = false;
                }


            }
        }
        else if (!Input.GetButton("Bbutton") || !Input.GetKeyDown(KeyCode.Escape))
        {
            keyButtonPressedBack = false;
        }
    }

    void buttonEnter() //untuk semua button back (enter/buttonA) di select level 
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButton("Abutton")) // nanti di ubah
        {
            if (!keyButtonPressedEnter) 
            {
                if (!isGoingToStore) 
                {
                    SelectPlanet.selectPlanet.enterToSelectLevel();
                }
            }

        }
        else if(!Input.GetKeyDown(KeyCode.Return) || !Input.GetButton("Abutton")) 
        {
            keyButtonPressedEnter = false;
        }
    }
    void inputToStore() 
    {
        if (!SelectPlanet.selectPlanet.isPlanetClicked) 
        {
            if (Input.GetButton("Xbutton") || Input.GetKeyDown(KeyCode.I))
            {
                isGoingToStore = true;
                

            }
        }
       
    }

    #endregion

    public void onClickBackToPlanet() 
    {
        isGoingToStore = false;
        storeStock.SetActive(false);

    }
    public void onClickBackToStore() 
    {
        AbilityButtonList.abilityButton.isClickedToUpgradePopUp = false;
       


    }
    public void onClickPlay() 
    {
        SceneManager.LoadScene("Scene firza");
    }
    IEnumerator BbuttonPress() 
    {
        if (keyButtonPressedBack) 
        {
            yield return new WaitForSeconds(0.1f);
            keyButtonPressedBack = false;
        }
    }
    
    






}
