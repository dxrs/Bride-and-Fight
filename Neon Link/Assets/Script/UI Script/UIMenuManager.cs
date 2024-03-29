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
    [SerializeField] GameObject confirmDeleteData;
    [SerializeField] GameObject objectClearData;

    [SerializeField] Button[] menuButton;
    [SerializeField] Button[] buttonConfirmDeleteData;
    [SerializeField] Button buttonClearData;
    [SerializeField] Button buttonExitSetting;
    [SerializeField] Button buttonLink;

    [SerializeField] TextMeshProUGUI textConfrimClearData;

    [SerializeField] Vector2[] selectorPos;


    [SerializeField] int[] curButtonValue;
    [SerializeField] int highLightButtonValue;
    [SerializeField] int clickedValue;

    [SerializeField] bool isAnimatedPopUp;
    [SerializeField] bool isInSettingMenu;


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
        for (int j = 0; j < buttonConfirmDeleteData.Length; j++)
        {
            buttonConfirmDeleteData[j].interactable = true;
        }
        if (Music.music.id == "Main Menu")
        {
            Music.music.audioSource.Play();
            Music.music.audioSource.volume = 0.7f;

        }
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
                    isInSettingMenu = true;
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
            if (Music.music.id == "Main Menu")
            {
                Music.music.audioSource.volume = Mathf.Lerp(Music.music.audioSource.volume, 0, 2 * Time.deltaTime);
            }

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
        for (int i = 0; i < menuButton.Length; i++)
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
            SoundEffect.soundEffect.audioSources[0].Play();
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
        SoundEffect.soundEffect.audioSources[0].Play();
        if (buttonMenuIsClicked)
        {
            buttonMenuIsClicked = false;
            confirmDeleteData.SetActive(false);
            objectClearData.SetActive(true);
            buttonClearData.interactable = true;
            for (int j = 0; j < buttonConfirmDeleteData.Length; j++)
            {
                buttonConfirmDeleteData[j].interactable = false;
            }
        }
    }

    public void onClickDeleteData()
    {
        SoundEffect.soundEffect.audioSources[0].Play();
        if (buttonMenuIsClicked)
        {
            confirmDeleteData.SetActive(true);
            objectClearData.SetActive(false);
            buttonClearData.interactable = false;

            for (int j = 0; j < buttonConfirmDeleteData.Length; j++)
            {
                buttonConfirmDeleteData[j].interactable = true;
            }

        }
    }

    public void onClickLinkButton() 
    {
        Application.OpenURL("https://linktr.ee/last_game?fbclid=PAAaZt_tncPvf6lxuPSh1n54lRW227VbXAK5-Wcu3viqicnbmVFj63rkasau4");
    }

    //NANTI DI HAPUS
    public void onClickCheatButton() 
    {
        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[4], 4);
        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[6], 4);
        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[1], 9999);
    }

    public void onClickNo() 
    {
        confirmDeleteData.SetActive(false);
        objectClearData.SetActive(true);
        buttonClearData.interactable = true;
        for (int j = 0; j < buttonConfirmDeleteData.Length; j++)
        {
            buttonConfirmDeleteData[j].interactable = false;
        }
    }
    public void onClickYes()
    {
     
        textConfrimClearData.text = "Clearing data";
        buttonExitSetting.interactable = false;
        for (int j = 0; j < buttonConfirmDeleteData.Length; j++)
        {
            buttonConfirmDeleteData[j].interactable = false;
        }
        for(int j = 0; j < checkListToggleButton.Length; j++) 
        {
            checkListToggleButton[j].interactable = false;
        }
        StartCoroutine(delayButtonClearDataEnable());
       
        
    }

    IEnumerator delayButtonClearDataEnable()
    {
        

        yield return new WaitForSeconds(1);
        SaveDataManager.saveDataManager.deleteData();
        visualValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[8], 1);
        sfxValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[9], 1);
        musicValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[10], 1);
        for (int j = 0; j < checkListToggleButton.Length; j++)
        {
            checkListToggleButton[j].interactable = true;
        }
        buttonExitSetting.interactable = true;
        textConfrimClearData.text = "You're about to clear save data";
        confirmDeleteData.SetActive(false);
        objectClearData.SetActive(true);
        buttonClearData.interactable = true;
    }

    #region toggle button
    public void toggleVisual()
    {
        if (isInSettingMenu) 
        {
            SoundEffect.soundEffect.audioSources[3].Play();
        }
        confirmDeleteData.SetActive(false);
        objectClearData.SetActive(true);
        buttonClearData.interactable = true;
        for (int j = 0; j < buttonConfirmDeleteData.Length; j++)
        {
            buttonConfirmDeleteData[j].interactable = false;
        }
        visualValue = checkListToggleButton[0].isOn ? 1 : 0;
        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[8], visualValue);
        PlayerPrefs.Save();
    }
    public void toggleMusic()
    {
        if (isInSettingMenu) 
        {
            SoundEffect.soundEffect.audioSources[3].Play();
        }

        confirmDeleteData.SetActive(false);
        objectClearData.SetActive(true);
        buttonClearData.interactable = true;
        for (int j = 0; j < buttonConfirmDeleteData.Length; j++)
        {
            buttonConfirmDeleteData[j].interactable = false;
        }
        musicValue = checkListToggleButton[2].isOn ? 1 : 0;
        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[10], musicValue);
        PlayerPrefs.Save();
        if (musicValue == 0) 
        {
            Music.music.objectDisable();
        }
        if (musicValue == 1) 
        {
            Music.music.objectEnable();
            if(Music.music.id=="Main Menu") 
            {
                Music.music.audioSource.Play();
                Music.music.audioSource.volume = 0.7f;
            }
        }

    }
    public void toggleSFX()
    {
        confirmDeleteData.SetActive(false);
        objectClearData.SetActive(true);
        buttonClearData.interactable = true;
        for (int j = 0; j < buttonConfirmDeleteData.Length; j++)
        {
            buttonConfirmDeleteData[j].interactable = false;
        }
        sfxValue = checkListToggleButton[1].isOn ? 1 : 0;
        PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[9], sfxValue);
        PlayerPrefs.Save();
        if (sfxValue == 0) 
        {
            SoundEffect.soundEffect.objectDisable();
        }
        if (sfxValue == 1) 
        {

            SoundEffect.soundEffect.audioSources[3].Play();
            SoundEffect.soundEffect.objectEnable();
        }
    }

  
    #endregion

}
