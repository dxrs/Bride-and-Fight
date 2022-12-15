using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityLevelStatus : MonoBehaviour
{
    [SerializeField] Image[] imageStatusLevel;

    private void Update()
    {
        
        // Menyimpan nilai curShadowLevel atau curStoneLevel ke dalam variabel
        if(SceneManagerStatus.sceneManagerStatus.sceneStats=="Select Level") 
        {
            int level = 0;
            if (AbilityButtonList.abilityButton.clickedValue == 1)
            {
                level = AbilityShadowUpgrade.abilityShadowUpgrade.curShadowLevel;
            }
            else if (AbilityButtonList.abilityButton.clickedValue == 2)
            {
                level = AbilityInfinityStoneUpgrade.abilityInfinityStoneUpgrade.curStoneLevel;
            }

            // Menampilkan gambar sesuai dengan level yang tersimpan di variabel
            for (int i = 0; i < level; i++)
            {
                imageStatusLevel[i].enabled = true;
            }

            for (int i = level; i < imageStatusLevel.Length; i++)
            {
                imageStatusLevel[i].enabled = false;
            }
           
        }
       


    }

}
