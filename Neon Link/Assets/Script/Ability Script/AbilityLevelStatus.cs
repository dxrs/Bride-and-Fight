using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityLevelStatus : MonoBehaviour
{
    //[SerializeField] string[] abilityDesc;

    [SerializeField] TextMeshProUGUI textStatusLevelUpgrade;
    [SerializeField] TextMeshProUGUI textAbilityDesc;

    int level = 0;

    private void Update()
    {

        textStatusLevelUpgrade.text = "Level " + level;
        // Menyimpan nilai curShadowLevel atau curStoneLevel ke dalam variabel
        if(SceneManagerStatus.sceneManagerStatus.sceneStats=="Select Level") 
        {

            int abilityIndex = AbilityButtonList.abilityButton.clickedValue - 1;
            int[] abilityLevel = {
                AbilityShadowUpgrade.abilityShadowUpgrade.curShadowLevel,
                AbilityInfinityStoneUpgrade.abilityInfinityStoneUpgrade.curStoneLevel
            };

            if (abilityIndex >= 0)
            {
                level = abilityLevel[abilityIndex];
                //textAbilityDesc.text = abilityDesc[abilityIndex];
            }



        }
       


    }

}
