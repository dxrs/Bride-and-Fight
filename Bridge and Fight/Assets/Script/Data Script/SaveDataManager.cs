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
        }
    }
    void currentLevelAbility()
    {
        //total ability
        if (!PlayerPrefs.HasKey(listDataName[4])) 
        {
            PlayerPrefs.SetInt(listDataName[4], 2);
        }

        if (!PlayerPrefs.HasKey(listDataName[2]))
        {
            PlayerPrefs.SetInt(listDataName[2], 1);
        }
        if (!PlayerPrefs.HasKey(listDataName[3])) 
        {
            PlayerPrefs.SetInt(listDataName[3], 1);
        }
    }
}
