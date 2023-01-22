using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    [SerializeField] ParticleSystem coinDestroyParticle;

    bool coinDestroying;
    bool isDestroyed = false;

    void Start()
    {
        StartCoroutine(delayCoinDestroy());
    }
    private void Update()
    {
        if (coinDestroying) 
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, Vector2.zero, 0.5f * Time.deltaTime);
        }
        if (transform.localScale.x == 0 && !isDestroyed) 
        { 
            Destroy(gameObject);
            isDestroyed = true;
        }
        
    }

    IEnumerator delayCoinDestroy() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(2);
            coinDestroying = true;
        }
    }
    private void OnDestroy()
    {
        if (isDestroyed) 
        {
           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player 1" 
            || collision.gameObject.tag == "Player 2"
            || collision.gameObject.tag=="Coin Colider")
        {
            Instantiate(coinDestroyParticle, transform.position, Quaternion.identity);
            TotalCoin.totalCoin.curCoinGet += 10;
            SoundEffect.soundEffect.audioSources[1].Play();
            Destroy(gameObject);
            
        }
    }


}
