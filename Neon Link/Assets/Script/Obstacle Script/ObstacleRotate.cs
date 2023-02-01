using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{
    public static ObstacleRotate obstacleRotate;

    [SerializeField] string rotType;

    [SerializeField] float timerRot;
    [SerializeField] float timerCooldDown;
    [SerializeField] float rotationSpeed;
    [SerializeField] float maxValue;
    [SerializeField] float minValue;

    [SerializeField] bool isRotate;
    [SerializeField] bool isClockwise;
    [SerializeField] bool isRandomSpeed;

    [SerializeField] BoxCollider2D[] bc;


    float curTimerRot;
    
    

    private void Awake()
    {
        if(obstacleRotate==null) { obstacleRotate = this; }
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        normalRotUpdate();
    }
    #region normal Rotate

    void normalRotUpdate() 
    {
        if (rotType == "Normal Rotate")
        {
            
            if (GameStarting.gameStarting.isGameStarted
                    && !GamePaused.gamePaused.isGamePaused)
            {

                transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            }
            if (GameFinish.gameFinish.isGameFinished) 
            {
                for(int a = 0; a < bc.Length; a++) 
                {
                    bc[a].enabled = false;
                }
            }
        }
       
        
    }

    #endregion
}
