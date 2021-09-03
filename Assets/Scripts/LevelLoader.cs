using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject[] LevelButtons;//no need to give refrencing to this array. find with tag will work. 

    void Start()
    {
        int levelReached=PlayerPrefs.GetInt("levelReached",0);
    
        //LevelButtons = GameObject.FindGameObjectsWithTag("LevelLoaderButton");
        for (int i = 0; i < levelReached; i++)
        {
            LevelButtons[i].GetComponent<Button>().interactable = true;
            LevelButtons[i].GetComponent<Image>().enabled = false;
        }
        
        int totalCoins = PlayerPrefs.GetInt("totalCoins", 0);
    }

    public void deactivating(){
        int levelReached=PlayerPrefs.GetInt("levelReached",0);
        if(levelReached == 13) levelReached = 12; // very imp
        for (int i = 0; i < levelReached; i++)  // if you win level n, then levelreached == n+1 that is = build index 
        {
            LevelButtons[i].GetComponent<Button>().interactable = false;
            LevelButtons[i].GetComponent<Image>().enabled = true;
        }
        PlayerPrefs.SetInt("levelReached",0);
        PlayerPrefs.SetInt("totalCoins", 0);
    }

    public void LoadScene(int BuildIndex)
    {
        SceneManager.LoadScene(BuildIndex);
    }
}
