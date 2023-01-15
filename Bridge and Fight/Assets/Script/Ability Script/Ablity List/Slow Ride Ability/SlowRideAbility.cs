using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRideAbility : MonoBehaviour
{
    [SerializeField] Vector2 maxScale;

    [SerializeField] float blastSpeed;

    [SerializeField] GameObject bigBlaster;

    int curAbilityLevel;



    private void Start()
    {
        curAbilityLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[11]);
        if (curAbilityLevel == 1) 
        {
            maxScale = new Vector2(5, 5);
            blastSpeed = 4;
        }
        if (curAbilityLevel == 2)
        {
            maxScale = new Vector2(10, 10);
            blastSpeed = 7;
        }
        if (curAbilityLevel == 3)
        {
            maxScale = new Vector2(12, 12);
            blastSpeed = 10;
        }
    }

    private void Update()
    {
       bigBlaster.transform.localScale = Vector2.MoveTowards(bigBlaster.transform.localScale,
            maxScale, blastSpeed * Time.deltaTime);


        if (bigBlaster.transform.localScale.x >= maxScale.x) 
        {
            Destroy(gameObject,4.5f);
        }
    }

   
}
