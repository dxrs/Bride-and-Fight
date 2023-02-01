using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowRideAbilityImage : MonoBehaviour
{
    [SerializeField] Image imgAbilityIcon;
    [SerializeField] int curUpLevelValue;
    string abilityName = "Slow Ride";

    private void Start()
    {
        curUpLevelValue = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[11]);

        UIStartGame.uIStartGame.abilityLeftName[3] = abilityName;
        UIStartGame.uIStartGame.abilityRightName[3] = abilityName;
    }
    private void Update()
    {
        if (GameStarting.gameStarting.isGameStarted && UIStartGame.uIStartGame.abilitySelectedValue == 3)
        {
            imgAbilityIcon.enabled = true;
            imgAbilityIcon.sprite = Resources.Load<Sprite>("Sprite/Ability Icon/Slow Ride/SR" + curUpLevelValue);
        }
    }
}
