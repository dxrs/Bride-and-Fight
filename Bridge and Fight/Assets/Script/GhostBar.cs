using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostBar : MonoBehaviour
{
    public Image barnya;

    float valuenya, maxValuernya = 5;
    // Start is called before the first frame update
    void Start()
    {
        valuenya = maxValuernya;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerInvisible.playerInvisible.isInvisible)
        {
            barnya.enabled = true;
        }
        else
        {
            barnya.enabled = false;
        }
        valuenya = PlayerInvisible.playerInvisible.waktuHantu;
        barFiller();
    }

    void barFiller()
    {
        barnya.fillAmount = valuenya / maxValuernya;
    }
}
