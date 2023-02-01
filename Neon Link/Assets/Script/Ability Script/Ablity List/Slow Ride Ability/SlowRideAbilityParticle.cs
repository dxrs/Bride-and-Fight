using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRideAbilityParticle : MonoBehaviour
{
    ParticleSystem ps;

 

    int curAbilityLevel;
    private void Awake()
    {
        
    }
    private void Start()
    {
        curAbilityLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[11]);
        ps = GetComponent<ParticleSystem>();

        var main = ps.main;

        if (curAbilityLevel == 1) 
        {
            //main.duration = 4;
        }
        if (curAbilityLevel == 2)
        {
            //main.duration = 7;
        }
        if (curAbilityLevel == 3)
        {
            //main.duration = 10;
        }
    }
}
