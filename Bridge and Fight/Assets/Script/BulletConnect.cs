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
        if (!PlayerDestroy.playerDestroy.isGameOver) 
        {
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
            if (Vector2.Distance(transform.position, targetBullet.transform.position) < distance
                && !LineOfRay.lineOfRay.isTouchObstcale) 
            {
                Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
            }
            
            yield return new WaitForSeconds(waitTimeToSpawn);
        }
    }
}
