using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataNameValue : MonoBehaviour
{
    [SerializeField] int coinData;
    [SerializeField] int bankData;
    [SerializeField] int shadowLevel;
    [SerializeField] int stoneLevel;
    [SerializeField] int totalAbility;

    private void Start()
    {
        //money
        coinData = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[0]);
        bankData= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);

        //ability
        shadowLevel= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[2]);
        stoneLevel= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[3]);

        //total ability
        totalAbility = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[4]);
    }
}
