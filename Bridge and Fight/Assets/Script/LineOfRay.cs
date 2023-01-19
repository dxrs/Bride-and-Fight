using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfRay : MonoBehaviour
{

    public static LineOfRay lineOfRay;

    public ParticleSystem laserParticle;

    public bool isTouchObstcale;

    public Transform target;
    public Transform[] lineTargets;
    public LayerMask layerMask;

    EnemyStatus enemyStatus;

    BullBoss bullBoss;
    private void Awake()
    {
        if (lineOfRay == null) { lineOfRay = this; }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver.gameOver.isGameOver && !ShadowAbility.shadowAbility.isShadowActivated) 
        {
            lineConnector();
        }

      


       
    }

    void lineConnector() 
    {
        RaycastHit2D hit = Physics2D.Linecast(lineTargets[0].transform.position, lineTargets[1].transform.position, layerMask);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "obstacle")
            {
                
                Debug.DrawLine(lineTargets[0].transform.position, lineTargets[1].position, Color.red);
                isTouchObstcale = true;
            }
            else if (hit.collider.gameObject.tag == "Medium Enemy" && BulletConnect.bulletConnect.isConnected)
            {
                
                Debug.DrawLine(lineTargets[0].transform.position, lineTargets[1].position, Color.blue);
                enemyStatus = hit.collider.gameObject.GetComponent<EnemyStatus>();
                enemyStatus.enemyHealth -= 10 * Time.deltaTime;

                
                
                if (enemyStatus.enemyHealth <= 0) 
                {
                    TotalCoin.totalCoin.curCoinGet += 4;
                }
               

            }
            else if(hit.collider.gameObject.tag=="Bull Boss" && BulletConnect.bulletConnect.isConnected && SceneManagerStatus.sceneManagerStatus.sceneStats=="Level Boss")
            {
                Debug.DrawLine(lineTargets[0].transform.position, lineTargets[1].position, Color.blue);

                if (!BullBoss.bullBoss.isChassingPlayer) 
                {
                    BullBoss.bullBoss.bullBossHealth -= 2 * Time.deltaTime;
                }
                
               
            }
            else if (hit.collider.gameObject.tag == "Normal Enemy" && BulletConnect.bulletConnect.isConnected)
            {
                enemyStatus = hit.collider.gameObject.GetComponent<EnemyStatus>();
                enemyStatus.enemyHealth -= 10;
                TotalCoin.totalCoin.curCoinGet += 2;
            } 
          
            else
            {
                
                Debug.DrawLine(lineTargets[0].transform.position, lineTargets[1].position, Color.green);
                isTouchObstcale = false;
                
            }

           
        }
    }


}
