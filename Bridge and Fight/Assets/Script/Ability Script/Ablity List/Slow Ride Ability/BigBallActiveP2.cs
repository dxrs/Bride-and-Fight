using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallActiveP2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UIStartGame.uIStartGame.abilitySelectedValue == 3)
        {
            gameObject.SetActive(true);
        }
    }
}
