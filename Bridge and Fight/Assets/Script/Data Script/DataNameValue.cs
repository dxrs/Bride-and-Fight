using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataNameValue : MonoBehaviour
{

    [SerializeField] int curLevel;
    [SerializeField] bool levelPurchased;

    [SerializeField] int coinData;
    [SerializeField] int bankData;

    [SerializeField] int shadowLevel;
    [SerializeField] int stoneLevel;
    [SerializeField] int mindControlLevel;
    [SerializeField] int slowRideLevel;


    [SerializeField] int totalAbility;

    [SerializeField] int visualValue;
    [SerializeField] int soundValue;
    [SerializeField] int musicValue;

   
    private void Update()
    {
        //level
        curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);
        if (PlayerPrefs.HasKey(SaveDataManager.saveDataManager.listDataName[7])) 
        {
            levelPurchased = true;
        }
        if (!PlayerPrefs.HasKey(SaveDataManager.saveDataManager.listDataName[7])) 
        {
            levelPurchased = false;
        }


        //money
        coinData = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[0]);
        bankData = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);

        //ability
        shadowLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[2]);
        stoneLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[3]);
        mindControlLevel= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[5]);
        slowRideLevel= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[11]);

        //total ability
        totalAbility = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[4]);

        //setting value
        visualValue= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[8]);
        soundValue= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[9]);
        musicValue= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[10]);
    }
}
