using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    [SerializeField] float slowTime = 0.5f;
    [SerializeField] float curTime = 1f;
    [SerializeField] float slowDuration = 1f;


    private void Update()
    {
        if (GameOver.gameOver.isGameOver)
        {
            StartCoroutine(slowMotion());
        }
    }

    IEnumerator slowMotion()
    {
      
        Time.timeScale = slowTime;
        yield return new WaitForSeconds(slowDuration);
        Time.timeScale = curTime;

    }
}
