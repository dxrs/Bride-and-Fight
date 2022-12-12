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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
