using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player 1" || collision.gameObject.tag == "Player 2")
        {
            TotalCoin.totalCoin.curCoinGet += 10;
            Destroy(gameObject);
        }
    }


}
