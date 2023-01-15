using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondsTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Normal Enemy" || collision.gameObject.tag == "Medium Enemy")
        {

            HypnotizedAbility.hypnotizedAbility.curEnemyHitValue++;
        }
    }
}
