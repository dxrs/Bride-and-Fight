using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus playerStatus;

    public int p1Health;
    public int p2Health;

    private void Awake()
    {
        if (playerStatus == null) { playerStatus = this; }
    }
}
