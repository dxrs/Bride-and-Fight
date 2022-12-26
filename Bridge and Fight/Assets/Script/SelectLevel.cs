using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SelectLevel : MonoBehaviour
{
    public static SelectLevel selectLevel;

    public GameObject[] levelPerPlanet;

    public bool isInSelectLevelSection;

    //input
    [Header("Pilih Level")]
    [SerializeField] bool keyEnterButonPressedLevel;
    [SerializeField] int[] curValueSelect;
    [SerializeField] int buttonLevelSelectValue;
    [SerializeField] int buttonLevelHighlightedValue;
    [SerializeField] GameObject selector;
    [SerializeField] Button[] levelButton1;
    [SerializeField] Button[] levelButton2;
    [SerializeField] Button[] levelButton3;

    int curLevel;
    int curPlanet;


    private void Awake()
    {
        selectLevel = this;
    }
    private void Start()
    {
        curPlanet= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[7]);
    }
    private void Update()
    {
        for(int j = 0; j < levelPerPlanet.Length; j++) 
        {
            if (!SelectPlanet.selectPlanet.isPlanetClicked) 
            {
                levelPerPlanet[j].SetActive(false);
            }
        }
        if (curPlanet == 1) 
        {
            if (SelectPlanet.selectPlanet.isPlanetClicked) 
            {
                if (SelectPlanet.selectPlanet.planetClickValue == 1) 
                {
                    levelPerPlanet[0].SetActive(true);
                }
            }
        }
    }

    void eventListLevelButton() 
    {
        
    }
}
