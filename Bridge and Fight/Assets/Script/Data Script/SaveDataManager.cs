using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveDataManager : MonoBehaviour
{
    public static SaveDataManager saveDataManager;

    public string[] listDataName;

    
 

    private void Awake()
    {
        saveDataManager = this;
    }
    private void Start()
    {
        currentLevelAbility();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            
            
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
        if (!PlayerPrefs.HasKey(listDataName[2]))
        {
            PlayerPrefs.SetInt(listDataName[2], 1);
        }
        if (!PlayerPrefs.HasKey(listDataName[3])) 
        {
            PlayerPrefs.SetInt(listDataName[3], 1);
        }
        if (!PlayerPrefs.HasKey(listDataName[5])) 
        {
            PlayerPrefs.SetInt(listDataName[5], 1);
        }
    }
}
