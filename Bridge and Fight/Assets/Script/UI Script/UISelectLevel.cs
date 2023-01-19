using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UISelectLevel : MonoBehaviour
{
    public static UISelectLevel uiselectLevel;


    public int totalLevel;
    public int levelButtonClickedValue;
    public int levelButtonHighlightValue;
    public int buttonLevelValueSelected;

    public bool isLevelButtonClicked;
    public bool isGoingToStore;

    public Button[] listButtonLevel;

    public GameObject sceneTransition;


    public int[] curValueSelect;
    public int[] levelPurchased;

    [SerializeField] Image shadowImageEffect1;
    [SerializeField] Image shadowImageEffect2;

    [SerializeField] bool isGoingToMenu;

    [SerializeField] GameObject levelSelector;
    [SerializeField] GameObject[] levelSelectorPos;
    [SerializeField] GameObject shopObject;
    [SerializeField] GameObject objHowToPlay;


    [SerializeField] Button[] otherButton;

    [SerializeField] TextMeshProUGUI textCoin;


    public int curLevel;
    int curCoin;
    bool gamePadPressed; // buat gamepad
    bool isTransition = false;

    private void Awake()
    {
        uiselectLevel = this;
    }

    private void Start()
    {
        curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);
        curCoin = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[0]);
        levelButtonHighlightValue = curLevel;

        eventController();
      
    }

    void eventController()
    {
        for (int j = 0; j < listButtonLevel.Length; j++)
        {
            int valueSelect = curValueSelect[j];

            //klik setiap button level
            listButtonLevel[j].onClick.AddListener(() => levelButtonClicked(valueSelect));

            //cursor highlight setiap button
            EventTrigger eventTrigger = listButtonLevel[j].gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((data) =>
            { levelButtonHighlighted(valueSelect); });
            eventTrigger.triggers.Add(entry);
        }
    }

    private void Update()
    {
        textCoin.text = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]).ToString();

        
        

        // reaksi button dan selector di select level ketika ke store
        if (isGoingToStore || isGoingToMenu || SceneManagerCallback.sceneManagerCallback.isGoingToLevel)
        {
            shadowImageEffect1.enabled = false;
            shadowImageEffect2.enabled = false;
            for (int i = 0; i < otherButton.Length; i++) { otherButton[i].interactable = false; }

        }

        if (!isGoingToStore && !isGoingToMenu && !SceneManagerCallback.sceneManagerCallback.isGoingToLevel)
        {
            shadowImageEffect1.enabled = true;
            shadowImageEffect2.enabled = true;
            for (int i = 0; i < otherButton.Length; i++) { otherButton[i].interactable = true; }
        }
        
        if (isLevelButtonClicked) 
        {
            if (levelButtonClickedValue == 1)
            {
                sceneAnimationTransition();
                StartCoroutine(SceneManagerCallback.sceneManagerCallback.loadToLevel1());
                for (int i = 0; i < listButtonLevel.Length; i++)
                {
                    listButtonLevel[i].interactable = false;
                }
            }
        }

        if (isGoingToMenu) 
        {
            sceneAnimationTransition();
            StartCoroutine(SceneManagerCallback.sceneManagerCallback.loadToMenu());
        }

        if (SceneManagerCallback.sceneManagerCallback.isGoingToLevel) 
        {
            levelSelector.SetActive(false);
        }
        if (isGoingToStore) 
        {
            shopObject.transform.localPosition = Vector2.MoveTowards(shopObject.transform.localPosition, new Vector2(0, 0), 10000 * Time.deltaTime);
        }
        else 
        {
            shopObject.transform.localPosition = Vector2.MoveTowards(shopObject.transform.localPosition, new Vector2(1920, 0), 10000 * Time.deltaTime);

        }

        

       
        // selector pos berdasarkan button level transform
        for (int i = 0; i < levelSelectorPos.Length; i++)
        {
            if (levelButtonHighlightValue == i+1)
            {
                levelSelector.transform.localPosition = levelSelectorPos[i].transform.localPosition;
                break;
            }
        }
    }

   

    void levelButtonClicked(int value) 
    {
        levelButtonClickedValue = value;

        if (levelButtonHighlightValue != 1) 
        {
            StartCoroutine(levelButtonSelectedDelay());
            
            if (buttonLevelValueSelected == 2)
            {
                isLevelButtonClicked = true;
            }
        }
        else 
        {
            isLevelButtonClicked = true;
        }
        

        
       
    }
    void levelButtonHighlighted(int value) 
    {
        if (value > curLevel) 
        {
            value = curLevel;
        }
       
        levelButtonHighlightValue = value;

        if (levelButtonHighlightValue == 1) 
        {
            buttonLevelValueSelected = 1;
        }
       
    }

    public void sceneAnimationTransition() 
    {
       
        sceneTransition.transform.localScale = Vector2.MoveTowards(sceneTransition.transform.localScale,
                new Vector2(30.0f, 30.0f),
                100 * Time.deltaTime);
        if (!isGoingToMenu) 
        {
            if (!isTransition)
            {
                SoundEffect.soundEffect.audioSources[7].Play();
                isTransition = true;
            }
            StartCoroutine(controlScheme());
        }
     
    }

    public void onClickToMenu() 
    {
        isGoingToMenu = true;
        SoundEffect.soundEffect.audioSources[0].Play();

    }
    public void onClickToStore() 
    {
        SoundEffect.soundEffect.audioSources[0].Play();
        levelButtonHighlightValue = 0;
        isGoingToStore = true;
        UIShop.uIShop.listAbilityButtonEnable();
    }
    IEnumerator levelButtonSelectedDelay() 
    {
        yield return new WaitForSeconds(0.5f);
        buttonLevelValueSelected = 2;

    }
    IEnumerator controlScheme() 
    {
        yield return new WaitForSeconds(1.2f);
        objHowToPlay.SetActive(true);
    }
}
