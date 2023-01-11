using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonLevel : MonoBehaviour
{
    public static ButtonLevel buttonLevel;

    public int id;
    [SerializeField] int levelCost;

    [SerializeField] int idStatus;

    [SerializeField] GameObject[] buttonLevelStatus;

    [SerializeField] TextMeshProUGUI textLevelCost;

    [SerializeField] Button levelButton;


    bool isPurchased = false;

    int curLevel;
    int indexButton = 0;
    int coin;
   
    private void Awake()
    {
        buttonLevel = this;
    }


    private void Start()
    {
        curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);
        coin= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);

        getIndexDataButtonValue();
        onStartButtonValue();

    }

    private void Update()
    {
        purchaseLevel();


        compareButtonValue();

    }


   

    #region purchase level

     void purchaseLevel()
    {
        if (UISelectLevel.uiselectLevel.isLevelButtonClicked && !isPurchased)
        {
            
            if (id == UISelectLevel.uiselectLevel.levelButtonClickedValue) 
            {

               
                  

                for (int i = 2; i <= UISelectLevel.uiselectLevel.curValueSelect.Length; i++)
                {
                    if (UISelectLevel.uiselectLevel.levelButtonClickedValue == i)
                    {
                        if (indexButton == 0)
                        {
                            if (coin < levelCost)
                            {
                                print("wah duit anda kurang");
                            }
                            if (coin >= levelCost)
                            {
                                print("anda membeli level " + id + " dengan harga " + levelCost);
                                idStatus = 1;
                                indexButton = idStatus;
                                coin -= levelCost;
                                PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[1], coin);
                                
                                UISelectLevel.uiselectLevel.levelPurchased[i - 2] = 1;
                                PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[7] + (i - 2),
                                    UISelectLevel.uiselectLevel.levelPurchased[i - 2]);

                                PlayerPrefs.Save();
                                
                            }

                        }
                        if (indexButton == 1)
                        {
                            print("masuk ke scene " + id);
                            SceneManagerCallback.sceneManagerCallback.masukKeSceneLevel();
                        }
                      


                       
                    }
                }


                isPurchased = true;
                
            }
            
            
           
        }
    }

    void onStartButtonValue() 
    {
       

        for (int i = 2; i <= UISelectLevel.uiselectLevel.curValueSelect.Length; i++)
        {
            if (UISelectLevel.uiselectLevel.levelPurchased[i - 2] == 1)
            {
                if (id == i)
                {
                    idStatus = 1;
                }
                else
                {
                    idStatus = 0;
                }
            }
        }
    }

    void compareButtonValue() 
    {
        if (id <= curLevel)
        {
            if (!SceneManagerCallback.sceneManagerCallback.isGoingToLevel) 
            {
                levelButton.interactable = true;

            }
            
            if (idStatus == 1)
            {
                buttonLevelStatus[0].SetActive(true);
                buttonLevelStatus[1].SetActive(false);


            }
            if (idStatus == 0)
            {
                buttonLevelStatus[0].SetActive(false);
                buttonLevelStatus[1].SetActive(true);

                textLevelCost.text = levelCost.ToString();
            }
            if (idStatus == 1 || idStatus == 0)
            {
                buttonLevelStatus[2].SetActive(false);
            }

        }
        if (id > curLevel)
        {
            buttonLevelStatus[0].SetActive(false);
            buttonLevelStatus[1].SetActive(false);
            buttonLevelStatus[2].SetActive(true);
            levelButton.interactable = false;
        }
    }
    void getIndexDataButtonValue() 
    {
        for (int i = 0; i < UISelectLevel.uiselectLevel.levelPurchased.Length; i++)
        {
            UISelectLevel.uiselectLevel.levelPurchased[i] = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[7] + i);
        }
    }

    #endregion

   
}