using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    public static ControlSystem controlSystem;

    public bool isSinglePlayer;

    private void Awake()
    {
        controlSystem = this;
    }

    
}
