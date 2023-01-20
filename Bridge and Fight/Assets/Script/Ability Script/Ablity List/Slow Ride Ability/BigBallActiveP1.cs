using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallActiveP1 : MonoBehaviour
{
    CircleCollider2D cc;
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cc.enabled = false;
        if (UIStartGame.uIStartGame.abilitySelectedValue == 3) 
        {
          
        }
    }
}
