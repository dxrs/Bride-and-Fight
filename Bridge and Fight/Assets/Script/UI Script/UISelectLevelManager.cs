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

    [SerializeField] string[] joyStickInputName;
    [SerializeField] GameObject[] objectUpgrade;
        
    [Header("Boolean Controller")]
    public bool keyButtonPressedBack;
    public bool keyButtonPressedEnter;
    public bool keyButtonOressedlbrb;

    [Header("Alfa Store")]
    public int chooseStoreValue = 1;
    [SerializeField] Button buttonBackToSelectLevel;
    [SerializeField] GameObject abilityShowUp;
    [SerializeField] GameObject alfaStore;
    [SerializeField] GameObject storeStock;
    [SerializeField] Button buttonUp;
    [SerializeField] Button buttonStore;
    [SerializeField] TextMeshProUGUI textMoney;
    [SerializeField] TextMeshProUGUI textStoreChoose;
    [SerializeField] TextMeshProUGUI[] textIconChoose;

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

        if (chooseStoreValue == 1) 
        {
            textStoreChoose.text = "ABILITY";
        }
        if (chooseStoreValue == 2) 
        {
            textStoreChoose.text = "SKIN";
        }

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
        inputChooseStore();

        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            // tampilkan cursor jika mouse di-swipe

            Cursor.visible = true;
            if (AbilityButtonList.abilityButton.isClickedToUpgradePopUp) 
            {
                objectUpgrade[0].SetActive(true);
                objectUpgrade[1].SetActive(false);
            }
        }
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0
            ||Input.anyKeyDown)
        {
            textIconChoose[0].text = "[";
            textIconChoose[1].text = "]";
        }
        else 
        {
            for(int i = 0; i < joyStickInputName.Length; i++) 
            {
                //float buttonAxis = Input.GetAxis(joyStickInputName[i]);
                if (Input.GetButton(joyStickInputName[i])) 
                {
                    textIconChoose[0].text = "L";
                    textIconChoose[1].text = "R";
                    Cursor.visible = false;
                }

               
                
            }
        }

        if (AbilityButtonList.abilityButton.isClickedToUpgradePopUp)
        {
            for (int i = 0; i < joyStickInputName.Length; i++)
            {

                if (Input.anyKeyDown || Input.GetButton(joyStickInputName[i]))
                {
                    objectUpgrade[0].SetActive(false);
                    objectUpgrade[1].SetActive(true);
                }


            }
           
        }





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
                    SelectPlanet.selectPlanet.planetClickValue = 0;
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

                if (isGoingToStore) 
                {
                    AbilityButtonList.abilityButton.onEnterAbilitySelect();
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
    void inputChooseStore() 
    {
        
        if (isGoingToStore && !AbilityButtonList.abilityButton.isClickedToUpgradePopUp)
        {
            if (Input.GetKeyDown(KeyCode.LeftBracket)) //[
            {
                
                Cursor.visible = false;
                keyButtonOressedlbrb = true;
                chooseStoreValue--;
                if (chooseStoreValue < 1)
                {
                    chooseStoreValue = 2;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightBracket)) //]
            {
                Cursor.visible = false;
                keyButtonOressedlbrb = true;
                chooseStoreValue++;
                if (chooseStoreValue > 2)
                {
                    chooseStoreValue = 1;
                }
            }



            if (Input.GetButton("RBbutton") && !keyButtonOressedlbrb)
            {
                Cursor.visible = false;
                keyButtonOressedlbrb = true;
                chooseStoreValue++;
                if (chooseStoreValue > 2)
                {
                    chooseStoreValue = 1;
                }
                

            }

            if (Input.GetButton("LBbutton") && !keyButtonOressedlbrb)
            {
                Cursor.visible = false;
                keyButtonOressedlbrb = true;
                chooseStoreValue--;
                if (chooseStoreValue < 1)
                {
                    chooseStoreValue = 2;
                }
               
            }

            if (!Input.GetButton("LBbutton") && !Input.GetButton("RBbutton"))
            {
                keyButtonOressedlbrb = false;
            }

        }


        


    }

    #endregion

    public void onClickChooseStoreLeft() 
    {
        chooseStoreValue--;
        if (chooseStoreValue < 1)
        {
            chooseStoreValue = 2;
        }
    }
    public void onClickChooseStoreRight() 
    {
        chooseStoreValue++;
        if (chooseStoreValue > 2)
        {
            chooseStoreValue = 1;
        }
    }

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
    
    
    






}
