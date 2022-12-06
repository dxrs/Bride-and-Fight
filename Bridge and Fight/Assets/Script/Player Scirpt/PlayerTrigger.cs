using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public static PlayerTrigger playerTrigger;

    public bool p1, p2;
    [SerializeField] int numbPlayer;
    private void Awake()
    {
        if (playerTrigger == null) { playerTrigger = this; }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Camera Edge") 
        {
            if (numbPlayer == 1) 
            {
                p1 = true;
            }
            if (numbPlayer == 2) 
            {
                p2 = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Camera Edge")
        {
            if (numbPlayer == 1)
            {
                p1 = false;
            }
            if (numbPlayer == 2)
            {
                p2 = false;
            }
        }
    }
}
