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

    public bool isLevelButtonClicked;
    public bool isGoingToStore;

    public Button[] listButtonLevel;
   

    public int[] curValueSelect;
    public int[] levelPurchased;

    [SerializeField] bool isGoingToMenu;

    [SerializeField] GameObject levelSelector;

    [SerializeField] GameObject[] levelSelectorPos; // mungkin di ganti atau hapus

    [SerializeField] Button[] otherButton;

    [SerializeField] TextMeshProUGUI textCoin;


    public int curLevel;
    int curCoin;
    bool gamePadPressed; // buat gamepad

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

        // klo cursor highight ke button yang lebih dari cur level
        // cur level berdasarkan data level
        if (levelButtonHighlightValue > curLevel)
        {
            levelButtonHighlightValue = curLevel;
        }

        // reaksi button dan selector di select level ketika ke store
        if (isGoingToStore || isGoingToMenu || isLevelButtonClicked)
        {
           
            for (int i = 0; i < otherButton.Length; i++) { otherButton[i].interactable = false; }

        }

        if (!isGoingToStore && !isGoingToMenu && !isLevelButtonClicked) 
        {
            for (int i = 0; i < otherButton.Length; i++) { otherButton[i].interactable = true; }
        }



        if (!isGoingToStore && !isGoingToMenu)
        {
            if (isLevelButtonClicked)
            {
                levelSelector.SetActive(false);
                for (int i = 0; i < listButtonLevel.Length; i++)
                {
                    listButtonLevel[i].interactable = false;
                }
            }
            else
            {
                levelSelector.SetActive(true);
                for (int i = 0; i < listButtonLevel.Length; i++)
                {
                    listButtonLevel[i].interactable = true;
                }
            }
        }

        //button interaksi tergantung total current level
        for (int x = 0; x < listButtonLevel.Length; x++)
        {
            if (x < curLevel && !isLevelButtonClicked)
            {
                listButtonLevel[x].interactable = true;
            }
            else
            {
                listButtonLevel[x].interactable = false;
            }
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
        isLevelButtonClicked = true;

        
        Debug.Log("clicked " + levelButtonClickedValue);
    }
    void levelButtonHighlighted(int value) 
    {
        if (value > curLevel) 
        {
            value = curLevel;
        }
       
        levelButtonHighlightValue = value;
        Debug.Log("cursor " + levelButtonHighlightValue);
    }

    public void onClickToMenu() 
    {
        
    }
    public void onClickToStore() 
    {
        levelButtonHighlightValue = 0;
    }
}
