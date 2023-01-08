using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SelectLevel : MonoBehaviour
{
    public static SelectLevel selectLevel;


    public int totalLevel;
    public int levelButtonClickedValue;
    public int levelButtonHighlightValue;

    public bool isLevelButtonClicked;

    public Button[] listButtonLevel;

    [SerializeField] int[] curValueSelect;

    [SerializeField] GameObject levelSelector;

    [SerializeField] Vector2[] levelSelectorPos; // mungkin di ganti atau hapus

    [SerializeField] Button buttonStore;


    int curLevel;
    bool gamePadPressed; // buat gamepad

    private void Awake()
    {
        selectLevel = this;
    }

    private void Start()
    {
        curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);
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
            entry.callback.AddListener((data) =>
            { levelButtonHighlighted(valueSelect); });
            eventTrigger.triggers.Add(entry);
        }
    }

    private void Update()
    {
        // klo cursor highight ke button yang lebih dari cur level
        // cur level berdasarkan data level
        if (levelButtonHighlightValue > curLevel) 
        {
            levelButtonHighlightValue = curLevel;
        }

        // reaksi button dan selector di select level ketika ke store
        if (UISelectLevelManager.uISelectLevelManager.isGoingToStore) 
        {
            levelSelector.SetActive(false);
            for(int i = 0; i < listButtonLevel.Length; i++) 
            {
                listButtonLevel[i].interactable = false;
            }
        }
    }

    void levelButtonClicked(int value) 
    {
        levelButtonClickedValue = value;
    }
    void levelButtonHighlighted(int value) 
    {
        levelButtonHighlightValue = value;
    }
}
