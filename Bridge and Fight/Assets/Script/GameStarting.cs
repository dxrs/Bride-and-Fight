using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarting : MonoBehaviour
{
    public static GameStarting gameStarting;

    public bool isGameStarted;

    private void Awake()
    {
        gameStarting = this;
    }
}
