using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataManager saveDataManager;

    public string[] listDataName;

    [SerializeField] int dataCoin;

    private void Awake()
    {
        saveDataManager = this;
    }
}
