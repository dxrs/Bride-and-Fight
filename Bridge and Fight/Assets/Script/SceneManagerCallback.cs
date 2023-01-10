using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerCallback : MonoBehaviour
{
    public static SceneManagerCallback sceneManagerCallback;

    public string[] sceneNameForLevel;

    private void Awake()
    {
        sceneManagerCallback = this;
    }
    private void Start()
    {
        idLevelPerSceneIndex();
    }
  
   
    public void idLevelPerSceneIndex() 
    {
        if (SceneManagerStatus.sceneManagerStatus.sceneStats == "Level") 
        {
            UIStartGame.uIStartGame.idLevel = SceneManager.GetActiveScene().buildIndex;
        }
       
    }
    // KE SELECT LEVEL SCENE
    #region
    public void keSceneSelectLevel() 
    {
        SceneManager.LoadScene("Scene Select Level"); // nanti di ubah sesuai index
    }
    #endregion

    // RESTART SCENE
    #region
    public void restartScene() 
    {
        StartCoroutine(waitForRestart());
    }

    IEnumerator waitForRestart() 
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion

}
