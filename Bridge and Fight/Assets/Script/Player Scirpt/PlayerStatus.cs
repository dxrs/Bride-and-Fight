using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus playerStatus;

    public int playerHealth;
    //public int p2Health;

    private void Awake()
    {
        if (playerStatus == null) { playerStatus = this; }
    }

    private void Update()
    {
        if (playerHealth <= 0) 
        {
            GameOver.gameOver.isGameOver = true;
        }
    }
}
