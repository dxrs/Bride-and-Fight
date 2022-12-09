using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver gameOver;

    public bool isGameOver;

    private void Awake()
    {
        gameOver = this;
    }
}
