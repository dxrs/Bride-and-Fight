using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIMenuManager : MonoBehaviour
{
    public static UIMenuManager uIMenuManager;

    public bool buttonMenuIsClicked;

    [SerializeField] GameObject selector;
    [SerializeField] GameObject sceneTransitionObj;

    [SerializeField] Button[] menuButton;

    [SerializeField] Vector2[] selectorPos;
    

    [SerializeField] int[] curButtonValue;
    [SerializeField] int highLightButtonValue;
    [SerializeField] int clickedValue;

    bool isGoingToSelectLevel = false;

    Vector2 transitionObject = new Vector2(30, 30);

    private void Awake()
    {
        uIMenuManager = this;
    }

    private void Start()
    {
        
        buttonEventList();
    }

    private void Update()
    {
        for(int x = 0; x < selectorPos.Length; x++) 
        {
            if (highLightButtonValue == x+1) 
            {
                selector.transform.localPosition = selectorPos[x];
                break;
            }
        }

       
        for (int i = 0; i < menuButton.Length; i++)
        {
            if (buttonMenuIsClicked)
            {
                if (clickedValue == 1)
                {
                    isGoingToSelectLevel = true;
                }
                menuButton[i].interactable = false;

            }
            else 
            {
                menuButton[i].interactable = true;
            }
        }

        if (isGoingToSelectLevel) 
        {
            sceneTransitionObj.transform.localScale = Vector2.MoveTowards(sceneTransitionObj.transform.localScale,
                transitionObject, 100 * Time.deltaTime);
            StartCoroutine(goingToSelectLevel());
        }
    }

    void buttonEventList() 
    {
        for(int i = 0; i < menuButton.Length; i++) 
        {
            int buttonValue = curButtonValue[i];

            menuButton[i].onClick.AddListener(() => menuButtonClicked(buttonValue));

            EventTrigger eventTrigger = menuButton[i].gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((data) => { menuButtonHighlighted(buttonValue); });
            eventTrigger.triggers.Add(entry);
        }
    }

    void menuButtonClicked(int value) 
    {
        clickedValue = value;
        buttonMenuIsClicked = true;
    }

    void menuButtonHighlighted(int value) 
    {
        highLightButtonValue = value;
    }

    IEnumerator goingToSelectLevel() 
    {
        if (sceneTransitionObj.transform.localScale.x >= 30) 
        {
            yield return new WaitForSeconds(2);
            SceneManagerCallback.sceneManagerCallback.keSceneSelectLevel();
        }
    }



}
