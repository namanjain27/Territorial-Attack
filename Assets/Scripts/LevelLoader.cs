using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject[] LevelButtons;

    void Start()
    {
        int levelReached=PlayerPrefs.GetInt("levelReached",0);

        LevelButtons = GameObject.FindGameObjectsWithTag("LevelLoaderButton");
        for (int i = 0; i < levelReached; i++)
        {
            LevelButtons[i].GetComponent<Button>().interactable = true;
            LevelButtons[i].GetComponent<Image>().enabled = false;
        }
        
        int totalCoins = PlayerPrefs.GetInt("totalCoins", 0);
    }

    public void deactivating(){
        int levelReached=PlayerPrefs.GetInt("levelReached",0);
        for (int i = 0; i < levelReached; i++)
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
