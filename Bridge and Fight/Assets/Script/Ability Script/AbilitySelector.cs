using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySelector : MonoBehaviour
{
    public static AbilitySelector abilitySelector;

    public int abilitySelected;

    [SerializeField] Image[] imgAbility;

    int curSkill_1, curSkill_2;


    private void Awake()
    {
        abilitySelector = this;
    }

    private void Start()
    {
        curSkill_1 = AbilityInventory.abilityInventory.skill_1;
        curSkill_2 = AbilityInventory.abilityInventory.skill_2;
    }
    public void onClickButtonA() 
    {
        GameStarting.gameStarting.isGameStarted=true;
        curSkill_1 = AbilityInventory.abilityInventory.skill_1;
        abilitySelected = curSkill_1;
        Cursor.visible = false;
        
    }

    public void onClickButtonB() 
    {
        GameStarting.gameStarting.isGameStarted = true;
        curSkill_2 = AbilityInventory.abilityInventory.skill_2;
        abilitySelected = curSkill_2;
        Cursor.visible = false;
    }


}
