using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerCallback : MonoBehaviour
{
    public static SceneManagerCallback sceneManagerCallback;

    public bool isGoingToLevel;


    private void Awake()
    {
        if (sceneManagerCallback == null) { sceneManagerCallback = this; }
        
    }
    private void Start()
    {
       
    }
  
   
    public void idLevelPerSceneIndex() 
    {
        if (SceneManagerStatus.sceneManagerStatus.sceneStats == "Level") 
        {
            UIStartGame.uIStartGame.idLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);
        }
       
    }

    public void masukKeSceneLevel() 
    {
        StartCoroutine(loadingLevel());
    }
    IEnumerator loadingLevel() 
    {
        isGoingToLevel = true;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(UISelectLevel.uiselectLevel.levelButtonClickedValue);
       
        
        
    }

    public IEnumerator loadToLevel1() 
    {
        isGoingToLevel = true;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Level 1");
    }

    public IEnumerator loadToMenu() 
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Scene Menu");
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