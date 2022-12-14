using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePaused : MonoBehaviour
{
    public static GamePaused gamePaused;

    public bool isGamePaused;

    float curTimeScale = 1;
    float pauseTimeScale = 0;

    private void Awake()
    {
        gamePaused = this;
    }
    private void Update()
    {
        if (isGamePaused) 
        {
            Time.timeScale = pauseTimeScale;
        }
        else 
        {
            Time.timeScale = curTimeScale;
        }
    }
}
