using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class SelectPlanet : MonoBehaviour
{
    public static SelectPlanet selectPlanet;

    [SerializeField] int clampLevel;

    [Header("Planet Selector Variable")]
    public int maxPlanet;
    public int planetClickValue;
    public int planetHighLightValue;
    public bool isPlanetClicked;
    public Button[] planetListButton;
    [SerializeField] int[] curValueSelect;
    [SerializeField] GameObject planetSelector;
    [SerializeField] Vector2[] planetSelectorPos;
    [SerializeField] Image planetSelectorImage;
    [SerializeField] Color[] planetSelectorColor;


    int curLevel;
    bool dpadPressed = false;

    private void Awake()
    {
        selectPlanet = this;
    }

    private void Start()
    {
        curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);
        if (curLevel >= 1 && curLevel <= 10)
        {
            planetHighLightValue = 1;
        }
        for (int j=0; j < planetListButton.Length; j++) 
        {
            int valueSelect = curValueSelect[j];

            //klik planet
            planetListButton[j].onClick.AddListener(() => planetButtonClicked(valueSelect));

            //highlight button planet
            EventTrigger eventTrigger = planetListButton[j].gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((data) =>
            { planetButtonHighLighted(valueSelect); });
            eventTrigger.triggers.Add(entry);
        }
    }

    private void Update()
    {

        for (int i = 0; i < planetSelectorPos.Length; i++)
        {
            if (planetHighLightValue == i + 1)
            {
                planetSelector.transform.localPosition = planetSelectorPos[i];
                planetSelectorImage.color = planetSelectorColor[i];
                break;
            }
        }

        if (maxPlanet > 0 && !UISelectLevelManager.uISelectLevelManager.isGoingToStore)
        {
            if (isPlanetClicked)
            {
                planetSelector.SetActive(false);
                for (int k = 0; k < planetListButton.Length; k++)
                {
                    planetListButton[k].interactable = false;
                }
            }
            else
            {
                planetSelector.SetActive(true);
                for (int k = 0; k < planetListButton.Length; k++)
                {
                    planetListButton[k].interactable = true;
                }
            }
        }
        else
        {
            planetSelector.SetActive(false);
        }

        if (planetHighLightValue > maxPlanet)
        {
            planetHighLightValue = maxPlanet;
        }

        for (int k = 0; k < planetListButton.Length; k++)
        {
            if (k < maxPlanet)
            {
                planetListButton[k].interactable = true;
            }
            else
            {
                planetListButton[k].interactable = false;
            }
        }


        planetSelectionInput();
       
       
    }

    void planetButtonHighLighted(int values) 
    {
        planetHighLightValue = values;
        if (values > maxPlanet) 
        {
            
        }
        
        Debug.Log(planetHighLightValue);
    }

    void planetButtonClicked(int values) 
    {
        planetClickValue = values;
        Debug.Log(planetClickValue);
        isPlanetClicked = true;
    }

    #region planetSelectionControl

    void planetSelectionInput() 
    {
       
        if(!isPlanetClicked && !UISelectLevelManager.uISelectLevelManager.isGoingToStore)
        {
            if (Input.GetKeyDown(KeyCode.D)
                || Input.GetKeyDown(KeyCode.RightArrow)
                || Input.GetAxis("DPadRight") > 0 && !dpadPressed)
            {
                Cursor.visible = false;
                dpadPressed = true;
                planetHighLightValue++;
                if (planetHighLightValue > maxPlanet)
                {
                    planetHighLightValue = 1;
                }
            }
            else if (Input.GetAxis("DPadRight") == 0)
            {
                dpadPressed = false;
            }
            if (Input.GetKeyDown(KeyCode.A)
                || Input.GetKeyDown(KeyCode.LeftArrow)
                || Input.GetAxis("DPadLeft") < 0 && !dpadPressed)
            {
                Cursor.visible = false;
                dpadPressed = true;
                planetHighLightValue--;
                if (planetHighLightValue < 1)
                {
                    planetHighLightValue = maxPlanet;
                }
            }
            else if (Input.GetAxis("DPadLeft") == 0)
            {
                dpadPressed = false;
            }


        }



    }
    public void enterToSelectLevel() 
    {
        Cursor.visible = false;
        UISelectLevelManager.uISelectLevelManager.isGoingToStore = false;
        for (int x = 1; x <= maxPlanet; x++) //max planet
        {
            if (planetHighLightValue == x)
            {
                planetClickValue = planetHighLightValue;
                isPlanetClicked = true;
                print("ke planet " + x + "click" + planetClickValue);
                break;
            }
        }
      
    }

    #endregion

    public void onClickStore() 
    {
        UISelectLevelManager.uISelectLevelManager.isGoingToStore = true;
        //UISelectLevelManager.uISelectLevelManager.inputValue[0] = 1;
    }
}
