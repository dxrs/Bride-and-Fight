using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIMenuManager : MonoBehaviour
{
    public static UIMenuManager uIMenuManager;

    public bool buttonMenuIsClicked;

    [SerializeField] GameObject selector;
    [SerializeField] GameObject sceneTransitionObj;
    [SerializeField] GameObject objectSetting;
    [SerializeField] GameObject objectCredit;

    [SerializeField] Button[] menuButton;

    [SerializeField] Vector2[] selectorPos;
    

    [SerializeField] int[] curButtonValue;
    [SerializeField] int highLightButtonValue;
    [SerializeField] int clickedValue;

    [SerializeField] bool isAnimatedPopUp;


    [Header("TOGGLE")]
    [SerializeField] Toggle[] checkListToggleButton;
    [SerializeField] int visualValue;
    [SerializeField] int sfxValue;
    [SerializeField] int musicValue;

    bool isGoingToSelectLevel = false;

    Vector2 transitionObject = new Vector2(30, 30);

    private void Awake()
    {
        uIMenuManager = this;
    }

    private void Start()
    {
        Cursor.visible = true;
        buttonEventList();

        visualValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[8], 1);
        sfxValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[9], 1);
        musicValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[10], 1);
        checkListToggleButton[0].isOn = visualValue == 1;
        checkListToggleButton[1].isOn = sfxValue == 1;
        checkListToggleButton[2].isOn = musicValue == 1;
    }

    private void Update()
    {
        if (!buttonMenuIsClicked) 
        {
            for (int x = 0; x < selectorPos.Length; x++)
            {
                if (highLightButtonValue == x + 1)
                {
                    selector.transform.localPosition = selectorPos[x];
                    break;
                }
            }
        }
        

       
        for (int i = 0; i < menuButton.Length; i++)
        {
            if (buttonMenuIsClicked)
            {
                if (clickedValue == 1)
                {
                    isGoingToSelectLevel = true;
                }
                if (clickedValue == 2) 
                {
                    isAnimatedPopUp = true;
                }
                if (clickedValue == 4) 
                {
                    Application.Quit();
                }
                menuButton[i].interactable = false;

            }
            else 
            {
                isAnimatedPopUp = false;
                menuButton[i].interactable = true;
            }
        }

        if (!buttonMenuIsClicked) 
        {
            if (highLightButtonValue == 3)
            {
                objectCredit.SetActive(true);
            }
            else
            {
                objectCredit.SetActive(false);
            }
        }
       

        if (isGoingToSelectLevel) 
        {
            sceneTransitionObj.transform.localScale = Vector2.MoveTowards(sceneTransitionObj.transform.localScale,
                transitionObject, 100 * Time.deltaTime);
            StartCoroutine(goingToSelectLevel());
        }

        animatedPopUp();

        if (visualValue == 1)
        {
            checkListToggleButton[0].isOn = true;
        }
        else
        {
            checkListToggleButton[0].isOn = false;
        }

        if (sfxValue == 1)
        {
            checkListToggleButton[1].isOn = true;
        }
        else
        {
            checkListToggleButton[1].isOn = false;
        }

        if (musicValue == 1)
        {
            checkListToggleButton[2].isOn = true;
        }
        else
        {
            checkListToggleButton[2].isOn = false;
        }
    }

    void buttonEventList() 
    {
        for(int i = 0; i < menuButton.Length; i++) 
        {
            int buttonValue = curButtonValue[i];

            menuButton[i].onClick.AddListener(() => menuButtonClicked(buttonValue));

            EventTrigger eventTrigger = menuButton[i].gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((data) => { menuButtonHighlighted(buttonValue); });
            eventTrigger.triggers.Add(entry);
        }
    }

    void menuButtonClicked(int value) 
    {
        clickedValue = value;
        if (clickedValue != 3) 
        {
            buttonMenuIsClicked = true;
        }
       
    }

    void menuButtonHighlighted(int value) 
    {
        if (!buttonMenuIsClicked) 
        {
            highLightButtonValue = value;
        }
        
    }

    void animatedPopUp()
    {
        if (isAnimatedPopUp)
        {
            objectSetting.transform.localScale = Vector2.MoveTowards(objectSetting.transform.localScale,
                new Vector2(1, 1), 20 * Time.deltaTime);
        }
        else
        {
            objectSetting.transform.localScale = Vector2.MoveTowards(objectSetting.transform.localScale,
               new Vector2(0, 0), 20 * Time.deltaTime);
        }
    }

    IEnumerator goingToSelectLevel() 
    {
        if (sceneTransitionObj.transform.localScale.x >= 30) 
        {
            yield return new WaitForSeconds(2);
            SceneManagerCallback.sceneManagerCallback.keSceneSelectLevel();
        }
    }

    public void onClickExtToMainMenu() 
    {
        if (buttonMenuIsClicked) 
        {
            buttonMenuIsClicked = false;
        }
    }

    public void onClickDeleteData() 
    {
        if (buttonMenuIsClicked)
        {
            SaveDataManager.saveDataManager.deleteData();
            visualValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[8], 1);
            sfxValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[9], 1);
            musicValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[10], 1);
        }
    }

    #region toggle button
    public void toggleVisual()
    {
        visualValue = checkListToggleButton[0].isOn ? 1 : 0;
        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[8], visualValue);
        PlayerPrefs.Save();
    }
    public void toggleSFX()
    {
        sfxValue = checkListToggleButton[1].isOn ? 1 : 0;
        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[9], sfxValue);
        PlayerPrefs.Save();
    }

    public void toggleMusic()
    {
        musicValue = checkListToggleButton[2].isOn ? 1 : 0;
        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[10], musicValue);
        PlayerPrefs.Save();
    }
    #endregion

}
