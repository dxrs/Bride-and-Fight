using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullBossLookAt : MonoBehaviour
{
    GameObject player1;
    GameObject player2;

    [SerializeField] float speed;
    [SerializeField] float rotationModifier;

    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player 1");
        player2 = GameObject.FindGameObjectWithTag("Player 2");
    }

    private void FixedUpdate()
    {
        if(player1 != null && player2 != null) 
        {
            if (!BullBoss.bullBoss.isChassingPlayer && BullBoss.bullBoss.delayTimeToChase >= 5)
            {
                if (BullBoss.bullBoss.indexPlayer == 0) 
                {
                    Vector3 vectorToTarget = player1.transform.position - transform.position;
                    float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
                    Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                    transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
                }
                if (BullBoss.bullBoss.indexPlayer == 1) 
                {
                    Vector3 vectorToTarget = player2.transform.position - transform.position;
                    float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
                    Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                    transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
                }
            }
        }
      
    }
}
