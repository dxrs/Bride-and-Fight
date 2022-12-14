using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    public static GameFinish gameFinish;

    public bool isGameFinished;

    private void Awake()
    {
        gameFinish = this;
    }
}
