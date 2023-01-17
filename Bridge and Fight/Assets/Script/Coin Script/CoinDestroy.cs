using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    bool coinDestroying;
    void Start()
    {
        coinDestroying = true;
    }
    private void Update()
    {
        if (coinDestroying) 
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, Vector2.zero, 0.15f * Time.deltaTime);
        }
        if (transform.localScale.x == 0) { Destroy(gameObject); }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player 1" 
            || collision.gameObject.tag == "Player 2"
            || collision.gameObject.tag=="Coin Colider")
        {
            TotalCoin.totalCoin.curCoinGet += 10;
            Destroy(gameObject);
        }
    }


}
