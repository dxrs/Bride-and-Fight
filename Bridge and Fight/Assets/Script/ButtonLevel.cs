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
    [SerializeField] TextMeshProUGUI textNotEnoughCoin;
    [SerializeField] Button levelButton;
    


    bool isPurchased = false;
    int curLevel;
    int indexButton;
    int coin;
   
    private void Awake()
    {
        buttonLevel = this;
    }


    private void Start()
    {
        curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);
        //coin= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[1]);

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
        
        if (id == UISelectLevel.uiselectLevel.levelButtonClickedValue )
        {
            if (idStatus == 1)
            {
                if (UISelectLevel.uiselectLevel.buttonLevelValueSelected == 2 && UISelectLevel.uiselectLevel.isLevelButtonClicked)
                {
                    UISelectLevel.uiselectLevel.sceneAnimationTransition();
                    print("masuk ke scene " + id);

                    SceneManagerCallback.sceneManagerCallback.masukKeSceneLevel();

                }
                
            }
            if ( UISelectLevel.uiselectLevel.buttonLevelValueSelected == 1 && !isPurchased) 
            {
                for (int i = 2; i <= UISelectLevel.uiselectLevel.curValueSelect.Length; i++)
                {
                    if (UISelectLevel.uiselectLevel.levelButtonClickedValue == i)
                    {
                        if (indexButton == 0)
                        {
                            
                            if (UISelectLevel.uiselectLevel.bankValueData >= levelCost)
                            {
                                SoundEffect.soundEffect.audioSources[8].Play();
                                print("anda membeli level " + id + " dengan harga " + levelCost);
                                idStatus = 1;
                                indexButton = idStatus;
                                UISelectLevel.uiselectLevel.bankValueData -= levelCost;
                                PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[1], UISelectLevel.uiselectLevel.bankValueData);

                                UISelectLevel.uiselectLevel.levelPurchased[i - 2] = 1;
                                PlayerPrefs.SetInt(SaveDataManager.saveDataManager.listDataName[7] + (i - 2),
                                    UISelectLevel.uiselectLevel.levelPurchased[i - 2]);

                                PlayerPrefs.Save();

                                isPurchased = true;

                            }

                        }
                      


                    }
                }
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
        if (id == UISelectLevel.uiselectLevel.levelButtonHighlightValue) 
        {
            if (idStatus == 1) 
            {
                UISelectLevel.uiselectLevel.buttonLevelValueSelected = 2;
            }
            else 
            {
               
                
                UISelectLevel.uiselectLevel.buttonLevelValueSelected = 1;
            }

        }
        
       
        
        if (id <= curLevel)
        {
            if (!SceneManagerCallback.sceneManagerCallback.isGoingToLevel) 
            {
                levelButton.interactable = true;

            }
            
            if (idStatus == 1)
            {
                isPurchased = true;
                buttonLevelStatus[0].SetActive(true);
                buttonLevelStatus[1].SetActive(false);


            }
            if (idStatus == 0)
            {
                isPurchased = false;
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

    IEnumerator textEnable() 
    {
        textNotEnoughCoin.enabled = true;
        yield return new WaitForSeconds(0.2f);
        textNotEnoughCoin.enabled = false;

    }

    

   
}
