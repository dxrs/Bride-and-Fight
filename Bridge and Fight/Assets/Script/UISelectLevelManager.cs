using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UISelectLevelManager : MonoBehaviour
{
    public static UISelectLevelManager uISelectLevelManager;

    public int curBank;

    [Header("List DBMS Value")]
    [SerializeField] int coinData;

  
    private void Awake()
    {
        uISelectLevelManager = this;
    }

    private void Start()
    {
        coinData = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[0]);
        curBank = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);
        
    }

   


}
