using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSistem : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.back, 20 * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)) 
        {
            SceneManager.LoadScene("Scene Menu");
        }
        
    }
}
