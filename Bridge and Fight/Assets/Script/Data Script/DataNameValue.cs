using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataNameValue : MonoBehaviour
{

    [SerializeField] int curLevel;

    [SerializeField] int curPlanet;

    [SerializeField] int coinData;
    [SerializeField] int bankData;

    [SerializeField] int shadowLevel;
    [SerializeField] int stoneLevel;
    [SerializeField] int healLevel;

    [SerializeField] int totalAbility;

    private void Start()
    {
      

        
    }
    private void Update()
    {
        //level
        curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);


        //money
        coinData = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[0]);
        bankData = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);

        //ability
        shadowLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[2]);
        stoneLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[3]);
        healLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[5]);

        //total ability
        totalAbility = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[4]);
    }
}
