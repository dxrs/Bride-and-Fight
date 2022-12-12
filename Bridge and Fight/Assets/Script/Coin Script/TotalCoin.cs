using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCoin : MonoBehaviour
{
    public static TotalCoin totalCoin;

    public int curCoinGet;
    public int totalCoinGet;

    private void Awake()
    {
        totalCoin = this;
    }
}
