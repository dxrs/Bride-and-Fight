using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletConnect : MonoBehaviour
{
    public static BulletConnect bulletConnect;

    public GameObject targetBullet;
    public GameObject shootPoint;
    public GameObject bullet;

    public float distance;

    public bool isConnected;

    public bool playerTouchedObstacle;

    public LayerMask layerMask;

    [SerializeField] float speedBullet;
    [SerializeField] float waitTimeToSpawn;

    private void Awake()
    {
        if (bulletConnect == null) { bulletConnect = this; }
    }
    private void Start()
    {
        StartCoroutine(spawnBulletnya());
    }
    private void Update()
    {
        if (!GameOver.gameOver.isGameOver && !GameFinish.gameFinish.isGameFinished)
        {
            playerLineRay();
            if (Vector2.Distance(transform.position, targetBullet.transform.position) < distance)
            {
                isConnected = true;
            }
            else
            {
                isConnected = false;
            }
        }
       
        
       
    }
   

    IEnumerator spawnBulletnya() 
    {
        

        while (true)
        {
            if (!GameOver.gameOver.isGameOver && !GameFinish.gameFinish.isGameFinished)
            {
                if (UIStartGame.uIStartGame.levelType == "survive") 
                {
                    if (Vector2.Distance(transform.position, targetBullet.transform.position) < distance)
                    {
                        if (!LineOfRay.lineOfRay.isTouchObstcale)
                        {
                            Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
                        }
                    }
                }

                if (UIStartGame.uIStartGame.levelType == "protect") 
                {
                    if (Vector2.Distance(transform.position, targetBullet.transform.position) < distance)
                    {
                        if (!playerTouchedObstacle)
                        {
                            Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
                        }
                    }
                }
               
            }
           
           
           
            
            
            yield return new WaitForSeconds(waitTimeToSpawn);
        }
    }

    void playerLineRay() 
    {
        if (UIStartGame.uIStartGame.levelType == "protect") 
        {
            RaycastHit2D hit = Physics2D.Linecast(shootPoint.transform.position, targetBullet.transform.position, layerMask);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "obstacle")
                {

                    Debug.DrawLine(shootPoint.transform.position, targetBullet.transform.position, Color.red);
                    playerTouchedObstacle = true;
                }


                else
                {

                    Debug.DrawLine(shootPoint.transform.position, targetBullet.transform.position, Color.green);
                    playerTouchedObstacle = false;

                }


            }
        }
    }
}
