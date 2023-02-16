using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSystem : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
    }
    private void Update()
    {
        if (GameStarting.gameStarting.isGameStarted && !UIPauseGame.uIPauseGame.isSceneEnded) 
        {
            if(GameOver.gameOver.isGameOver || GameFinish.gameFinish.isGameFinished || GamePaused.gamePaused.isGamePaused) 
            {
                Cursor.visible = true;
            }
            if(!GamePaused.gamePaused.isGamePaused && !GameFinish.gameFinish.isGameFinished && !GameOver.gameOver.isGameOver) 
            {
                Cursor.visible=false;
            }
        }
        if (UIPauseGame.uIPauseGame.isSceneEnded) 
        {
            Cursor.visible = true;
        }
    }
}
