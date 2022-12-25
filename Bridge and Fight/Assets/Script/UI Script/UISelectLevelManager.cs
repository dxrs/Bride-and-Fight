using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

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
    [SerializeField] bool goblok;

    [Header("Alfa Store")]
    public int chooseStoreValue = 1;
    public int buttonUpExitValue=1; //khusus pas mau upgrade
    [SerializeField] int[] buttonValue;  //khusus pas mau upgrade
    [SerializeField] Button buttonBackToSelectLevel;
    [SerializeField] GameObject abilityShowUp;
    [SerializeField] GameObject alfaStore;
    [SerializeField] GameObject storeStock;
    [SerializeField] GameObject upgradeSelector;
    [SerializeField] Button buttonUp;
    [SerializeField] Button buttonStore;
    [SerializeField] Button[] buttonUpOrExit; //khusus pas mau upgrade
    [SerializeField] TextMeshProUGUI textMoney;
    [SerializeField] TextMeshProUGUI textStoreChoose;
    [SerializeField] TextMeshProUGUI[] textIconChoose;

    [Header("List DBMS Value")]
    [SerializeField] int coinData;
    public int curBank;


    bool dpadPressed = false;
  


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
        inputChooseUpgradeOrExit(); //khusus upgrade
        StartCoroutine(test());

        if (!goblok && AbilityButtonList.abilityButton.isClickedToUpgradePopUp) 
        {
            StartCoroutine(lagi());
        }

        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            // tampilkan cursor jika mouse di-swipe

            Cursor.visible = true;
            
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
                if (goblok)
                {
                    goblok = false;
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
        Debug.Log("Enter button pressed");
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButton("Abutton")) // nanti di ubah
        {
            if (!keyButtonPressedEnter)
            {
                if (!isGoingToStore)
                {
                    SelectPlanet.selectPlanet.enterToSelectLevel();
                }

                if (isGoingToStore && !AbilityButtonList.abilityButton.isClickedToUpgradePopUp)
                {
                    //keyButtonPressedEnter = true;
                    //print("klik tidak");
                    //AbilityButtonList.abilityButton.onEnterAbilitySelect();
                    //ok = 2;
                    

                }
                if (AbilityButtonList.abilityButton.isClickedToUpgradePopUp && buttonUpExitValue==1)
                {
                    if (goblok) 
                    {
                        keyButtonPressedEnter = true;
                        goblok = false;
                    }
                    // jika panel upgrade ability sedang ditampilkan, kembali ke panel store
                    //isGoingToStore = true;
                    //keyButtonPressedEnter = true;
                    //ok = 2;
                    // print("klik ok");
                    //print("nantu up");
                    //isGoingToStore = false;
                    

                }
            }

        }
        else if ( !Input.GetButton("Abutton"))
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

    void inputChooseUpgradeOrExit() // ini buat pas mau upgrade atau exit milih tombolnya dulu
    {
        if (buttonUpExitValue == 1) 
        {
            upgradeSelector.transform.localPosition = new Vector2(-320, upgradeSelector.transform.localPosition.y);
        }
        if (buttonUpExitValue == 2) 
        {
            upgradeSelector.transform.localPosition = new Vector2(320, upgradeSelector.transform.localPosition.y);
        }
        if (AbilityButtonList.abilityButton.isClickedToUpgradePopUp) 
        {
            for(int x = 0; x < buttonUpOrExit.Length; x++) 
            {
                int buttonValues = buttonValue[x];

                EventTrigger eventTrigger = buttonUpOrExit[x].gameObject.AddComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback.AddListener((data) => { buttonUpOrExitHighlight(buttonValues); });
                eventTrigger.triggers.Add(entry);
            }

            if(Input.GetAxis("DPadRight")>0 && !dpadPressed
                || Input.GetKeyDown(KeyCode.D)
                || Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                Cursor.visible = false;
                dpadPressed = true;
                buttonUpExitValue++;
                if (buttonUpExitValue > 2) 
                {
                    buttonUpExitValue = 1;
                }

            }
            else if (Input.GetAxis("DPadRight") == 0) 
            {
                dpadPressed = false;
            }

            if(Input.GetAxis("DPadLeft") < 0 && !dpadPressed
                || Input.GetKeyDown(KeyCode.A)
                || Input.GetKeyDown(KeyCode.LeftArrow)) 
            {
                Cursor.visible = false;
                dpadPressed = true;
                buttonUpExitValue--;
                if (buttonUpExitValue < 1) 
                {
                    buttonUpExitValue = 2;
                }
            }
            else if (Input.GetAxis("DPadLeft") == 0)
            {
                dpadPressed = false;
            }
        }
        else 
        {
            buttonUpExitValue = 1;
        }
    }

    void buttonUpOrExitHighlight(int value) 
    {
        buttonUpExitValue = value;
    }

    #endregion

    #region mouse onClick
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
    #endregion

    IEnumerator test() 
    {
        yield return new WaitForSeconds(1);
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButton("Abutton")) 
        {
            if (!goblok) 
            {
                if (!keyButtonPressedEnter) 
                {
                    if (isGoingToStore && !AbilityButtonList.abilityButton.isClickedToUpgradePopUp)
                    {
                        keyButtonPressedEnter = true;
                        goblok = true;
                        AbilityButtonList.abilityButton.onEnterAbilitySelect();
                    }
                }
                
            }
        }
        else if (!Input.GetButton("Abutton")) 
        {
            keyButtonPressedEnter = false;
        }
        print("ayolah");

    }
    IEnumerator lagi() 
    {
        yield return new WaitForSeconds(.1f);
        AbilityButtonList.abilityButton.isClickedToUpgradePopUp = false;
    }










}
