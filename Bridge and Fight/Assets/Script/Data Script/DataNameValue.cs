using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataNameValue : MonoBehaviour
{
    [SerializeField] int coinData;
    [SerializeField] int bankData;

    private void Start()
    {
        coinData = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[0]);
        bankData= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);
    }
}
