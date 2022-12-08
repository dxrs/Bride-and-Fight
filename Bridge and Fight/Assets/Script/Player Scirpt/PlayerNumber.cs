using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNumber : MonoBehaviour
{
    public static PlayerNumber playerNumber;

    public bool isSoloMode;

    private void Awake()
    {
        playerNumber = this;
    }
}
