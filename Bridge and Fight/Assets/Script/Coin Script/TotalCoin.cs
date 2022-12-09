using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCoin : MonoBehaviour
{
    public static TotalCoin totalCoin;

    public int curCoinGet;

    private void Awake()
    {
        totalCoin = this;
    }
}
