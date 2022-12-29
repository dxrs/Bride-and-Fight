using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : MonoBehaviour
{
    [SerializeField] bool isChassingEnemy;

    [SerializeField] float minDistanceFollowPlayer;
    [SerializeField] float moveLerpSpeed;
    [SerializeField] float enemyRadiusDetection; // jarak/radius lebah enemy
    [SerializeField] float wispMovementSpeed; // kecepatan wisp ke enemy
    [SerializeField] float wispOtherPlayerRadiusDetection; // radius lebah player lain

    [SerializeField] string[] enemyTag;
    [SerializeField] string wispTag;

    [SerializeField] GameObject followPlayer;


    private void Update()
    {
        if (!isChassingEnemy) 
        {
            if (Vector2.Distance(transform.localPosition,
                followPlayer.transform.position) > minDistanceFollowPlayer)
            {
                transform.localPosition = Vector2.Lerp(transform.localPosition, 
                    followPlayer.transform.position, moveLerpSpeed * Time.deltaTime);
            }
        }
       
    }
  
}
