using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    public static UIMenuManager uIMenuManager;

    [SerializeField] int valueSelector;
    [SerializeField] GameObject[] selector;

    private void Start()
    {
        valueSelector = 1;
       
    }
    private void Update()
    {
        if (valueSelector < 1)
        {
            valueSelector = 3;
        }
        if (valueSelector > 3)
        {
            valueSelector = 1;
        }
        inputSelector();
        posSelector();
    }
    void inputSelector() 
    {
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            valueSelector++;
           
        }
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            valueSelector--;
        }
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            if (valueSelector == 1) 
            {
                SceneManager.LoadScene("Scene firza");
            }else if (valueSelector == 2) 
            {

            }
            else 
            {
                Application.Quit();
            }
        }
    }

    void posSelector() 
    {
        if (valueSelector == 1) 
        {
            selector[0].SetActive(true);
            selector[1].SetActive(false);
            selector[2].SetActive(false);
        }
        if (valueSelector == 2) 
        {
            selector[0].SetActive(false);
            selector[1].SetActive(true);
            selector[2].SetActive(false);
        }
        if (valueSelector == 3) 
        {
            selector[0].SetActive(false);
            selector[1].SetActive(false);
            selector[2].SetActive(true);
        }
    }

   
}
