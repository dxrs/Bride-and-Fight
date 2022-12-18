using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall") 
        {
            Player1Health.player1Health.playerHealth = 0;
            Player2Health.player2Health.playerHealth = 0;
        }
    }
}
