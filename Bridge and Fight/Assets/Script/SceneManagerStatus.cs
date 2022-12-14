using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerStatus : MonoBehaviour
{
    public static SceneManagerStatus sceneManagerStatus;

    public string sceneStats;

    private void Awake()
    {
        sceneManagerStatus = this;
    }
}
