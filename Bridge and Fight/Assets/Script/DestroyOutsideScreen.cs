using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutsideScreen : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        PlayerDestroy.playerDestroy.isGameOver = true;
    }
}
