using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public static PlayerTrigger playerTrigger;

    public bool isP1_ColtoCamEdge, isP2_ColtoCamEdge;
    public bool colObstacle_p1, colObstacle_p2;

    [SerializeField] bool isLightColorChange;

    [SerializeField] SpriteRenderer lightPlayer;

    [SerializeField] ParticleSystem playerHitParticle;

    [SerializeField] string[] enemyTag;
    
  

    [SerializeField] int numbPlayer;
    private void Awake()
    {
        if (playerTrigger == null) { playerTrigger = this; }
    }

    private void Update()
    {
        if (UIStartGame.uIStartGame.abilitySelectedValue == 3)
        {
            lightPlayer.enabled = true;
            if (isLightColorChange)
            {
                lightPlayer.color = Color.Lerp(new Color(lightPlayer.color.r, lightPlayer.color.g, lightPlayer.color.b, lightPlayer.color.a),
               new Color(lightPlayer.color.r, lightPlayer.color.g, lightPlayer.color.b, 1), 5 * Time.deltaTime);
            }
            else
            {
                lightPlayer.color = Color.Lerp(new Color(lightPlayer.color.r, lightPlayer.color.g, lightPlayer.color.b, lightPlayer.color.a),
                new Color(lightPlayer.color.r, lightPlayer.color.g, lightPlayer.color.b, 0.2f), 3 * Time.deltaTime);

            }
        }
        else 
        {
            lightPlayer.enabled = false;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Camera Edge") 
        {
            if (numbPlayer == 1) 
            {
                isP1_ColtoCamEdge = true;
            }
            if (numbPlayer == 2) 
            {
                isP2_ColtoCamEdge = true;
            }
        }
        for(int j = 0; j < enemyTag.Length; j++) 
        {
            if (collision.gameObject.tag == enemyTag[j]) 
            {
                if (TotalCoin.totalCoin.curCoinGet > 0 && 
                    UIStartGame.uIStartGame.idLevel == 
                    PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6])) 
                {
                    TotalCoin.totalCoin.curCoinGet -= 2;
                }
                Instantiate(playerHitParticle, transform.position, Quaternion.identity);

                
                StartCoroutine(colorLight());
            }

            
        }
        if(collision.gameObject.tag=="Bull Boss") 
        {
            Instantiate(playerHitParticle, transform.position, Quaternion.identity);
            if (!UIPauseGame.uIPauseGame.isSceneEnded) 
            {
                SoundEffect.soundEffect.audioSources[10].Play();
            }
            
        }
        if (collision.gameObject.tag == "Coin") 
        {
            StartCoroutine(UIInGame.uIInGame.coinImageAnim());
        }
       
        
    }
   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Camera Edge")
        {
            if (numbPlayer == 1)
            {
                isP1_ColtoCamEdge = false;
            }
            if (numbPlayer == 2)
            {
                isP2_ColtoCamEdge = false;
            }
        }
        
    }

    IEnumerator colorLight() 
    {
        isLightColorChange = true;
       
        yield return new WaitForSeconds(0.6f);
        
        isLightColorChange = false;
    }
}
