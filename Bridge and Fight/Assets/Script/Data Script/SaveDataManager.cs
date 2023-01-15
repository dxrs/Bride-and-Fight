using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveDataManager : MonoBehaviour
{
    public static SaveDataManager saveDataManager;

    public string[] listDataName;

    int[] abilityListUpgradeDataValue = { 2, 3, 5, 11, 8, 9 ,10 };
 

    private void Awake()
    {
        saveDataManager = this;
    }
    private void Start()
    {
        currentLevelAbility();
    }

   
    public void deleteData() 
    {
        PlayerPrefs.DeleteAll();
        //level
        if (!PlayerPrefs.HasKey(listDataName[6]))
        {
            PlayerPrefs.SetInt(listDataName[6], 1);
        }

        //planet
        if (!PlayerPrefs.HasKey(listDataName[7]))
        {
            PlayerPrefs.SetInt(listDataName[7], 1);
        }

        //total ability
        if (!PlayerPrefs.HasKey(listDataName[4]))
        {
            PlayerPrefs.SetInt(listDataName[4], 2);
        }

        // list ability
        foreach (int indexDataAbility in abilityListUpgradeDataValue)
        {
            if (!PlayerPrefs.HasKey(listDataName[indexDataAbility]))
            {
                PlayerPrefs.SetInt(listDataName[indexDataAbility], 1);
            }
        }

    }
    void currentLevelAbility()
    {

        //level
        if (!PlayerPrefs.HasKey(listDataName[6])) 
        {
            PlayerPrefs.SetInt(listDataName[6], 1);
        }

        //planet
        if (!PlayerPrefs.HasKey(listDataName[7]))
        {
            PlayerPrefs.SetInt(listDataName[7], 1);
        }

        //total ability
        if (!PlayerPrefs.HasKey(listDataName[4])) 
        {
            PlayerPrefs.SetInt(listDataName[4], 2);
        }

        // list ability
        foreach(int indexDataAbility in abilityListUpgradeDataValue) 
        {
            if (!PlayerPrefs.HasKey(listDataName[indexDataAbility])) 
            {
                PlayerPrefs.SetInt(listDataName[indexDataAbility], 1);
            }
        }

       
    }
}
