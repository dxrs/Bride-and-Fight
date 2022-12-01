using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvisible : MonoBehaviour
{
    public static PlayerInvisible playerInvisible;
    public float waktuHantu = 3;

    public Color invisibleColor;

    public Color curColorP1;
    public Color curColorP2;

    public bool isInvisible;

    public SpriteRenderer spriteRendererp1,spriteRendererp2;



    private void Awake()
    {
        playerInvisible = this;
    }

    private void Start()
    {
        
    }
    private void Update()
    {
       
        if (!PlayerDestroy.playerDestroy.isGameOver) 
        {
            panggilwarna();
        }
       
       
    }

    void panggilwarna() 
    {

        if (LineOfRay.lineOfRay.isTouchObstcale || !BulletConnect.bulletConnect.isConnected) 
        {
            spriteRendererp1.color = invisibleColor;
            spriteRendererp2.color = invisibleColor;
            isInvisible = true;
            waktuHantu -=1* Time.deltaTime;
            if (waktuHantu <= 0) 
            {
                curColorP1 = new Color(0.2f, 0.8235294f, 0.8784314f, 1);
                spriteRendererp1.color = curColorP1;
                curColorP2 = new Color(0.8784314f, 0.4823529f, 0.2039216f, 1);
                spriteRendererp2.color = curColorP2;
                waktuHantu = 0;
                isInvisible = false;
            }
        }
        if (!LineOfRay.lineOfRay.isTouchObstcale && BulletConnect.bulletConnect.isConnected)
        {
            isInvisible = false;
            waktuHantu = 5;
            if (waktuHantu >= 5) 
            {
                
                curColorP1 = new Color(0.2f, 0.8235294f, 0.8784314f, 1);
                spriteRendererp1.color = curColorP1;
                curColorP2 = new Color(0.8784314f, 0.4823529f, 0.2039216f, 1);
                spriteRendererp2.color = curColorP2;
            }
        }
    }

    void warnaAsli()
    {
        if (!isInvisible) 
        {
            if (LineOfRay.lineOfRay.isTouchObstcale) 
            {
                curColorP1 = new Color(0.2f, 0.8235294f, 0.8784314f, 1);
                spriteRendererp1.color = curColorP1;
                curColorP2 = new Color(0.8784314f, 0.4823529f, 0.2039216f, 1);
                spriteRendererp2.color = curColorP2;
            }
          
        }
      
        
    }

    void warnaPalsu()
    {
        if (isInvisible) 
        {
            if (LineOfRay.lineOfRay.isTouchObstcale) 
            {
                spriteRendererp1.color = invisibleColor;
                spriteRendererp2.color = invisibleColor;
            }
           
        }
       
    }

    void tampungan()
    {
        if (!LineOfRay.lineOfRay.isTouchObstcale && BulletConnect.bulletConnect.isConnected)
        {
            curColorP1 = new Color(0.2f, 0.8235294f, 0.8784314f, 1);
            spriteRendererp1.color = curColorP1;
            curColorP2 = new Color(0.8784314f, 0.4823529f, 0.2039216f, 1);
            spriteRendererp2.color = curColorP2;
        }
        else if (LineOfRay.lineOfRay.isTouchObstcale || !BulletConnect.bulletConnect.isConnected)
        {
            spriteRendererp1.color = invisibleColor;
            spriteRendererp2.color = invisibleColor;
        }
    }

    IEnumerator test() 
    {
        yield return new WaitForSeconds(5);
        isInvisible = false;
        if (isInvisible) 
        {
            
        }
    }
}
