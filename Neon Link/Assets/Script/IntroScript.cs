using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    [SerializeField] GameObject sceneTransition;
    [SerializeField] bool isAnimatedTransition;
    [SerializeField]
    AudioSource introAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimatedTransition) 
        {
            sceneTransition.transform.localScale = Vector2.MoveTowards(sceneTransition.transform.localScale,
               new Vector2(30.0f, 30.0f),
               100 * Time.unscaledDeltaTime);
        }
    }

    public void introStart()
    {
        introAudio.Play();
    }

    public void introEnd()
    {
        isAnimatedTransition = true;
        StartCoroutine(loadToMenu());
    }

    IEnumerator loadToMenu()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Scene Menu");
    }
}
