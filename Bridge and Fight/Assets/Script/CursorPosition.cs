using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPosition : MonoBehaviour
{
    private void Update()
    {
        if (GamePaused.gamePaused.isGamePaused) 
        {
            // Mengubah posisi cursor sesuai dengan posisi tengah layar
            Vector3 newPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            transform.position = newPosition;
        }
    }
}
