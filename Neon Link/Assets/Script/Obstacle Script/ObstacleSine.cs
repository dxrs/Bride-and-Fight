using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSine : MonoBehaviour
{
    [SerializeField] string id;

    [SerializeField] float sineSpeed;
    [SerializeField] float sinePower;

    [SerializeField] bool isRandomPosOffset;

    float randomOffsetSinePos;

    private float xPos;
    private float yPos;
    private float time;

    Vector2 pos;

    private void Start()
    {
        randomOffsetSinePos = Random.Range(0, 2);
        pos = transform.position;
        xPos = transform.position.x;
        yPos = transform.position.y;
    }

    private void Update()
    {
        if (!GamePaused.gamePaused.isGamePaused && GameStarting.gameStarting.isGameStarted) 
        {
            sineObstacle2Arah();
           
           
        }
       
    }

    #region sine obstacle

    void sineObstacle2Arah() 
    {
        if (id == "xy")
        {
          
            if (!isRandomPosOffset)
            {
                if (!isRandomPosOffset)
                {
                    transform.position = pos + new Vector2(Mathf.Sin(sineSpeed * Time.time) * sinePower,
                     Mathf.Sin(sineSpeed * Time.time) * sinePower);
                }
            }
        }

        if(id== "-xy") 
        {
            if (!isRandomPosOffset)
            {
                if (!isRandomPosOffset)
                {
                    transform.position = pos + new Vector2(Mathf.Sin(-sineSpeed * Time.time) * sinePower,
                     Mathf.Sin(sineSpeed * Time.time) * sinePower);
                }
            }
        }
        if (id == "x-y") 
        {
            if (!isRandomPosOffset)
            {
                if (!isRandomPosOffset)
                {
                    transform.position = pos + new Vector2(Mathf.Sin(sineSpeed * Time.time) * sinePower,
                     Mathf.Sin(-sineSpeed * Time.time) * sinePower);
                }
            }
        }

        if (id == "-x-y") 
        {
            if (!isRandomPosOffset)
            {
                if (!isRandomPosOffset)
                {
                    transform.position = pos + new Vector2(Mathf.Sin(-sineSpeed * Time.time) * sinePower,
                     Mathf.Sin(-sineSpeed * Time.time) * sinePower);
                }
            }
        }
    }

    #endregion
}
