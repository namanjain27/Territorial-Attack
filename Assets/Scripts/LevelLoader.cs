using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject[] LevelButtons;
    // Start is called before the first frame update
    void Start()
    {
        int levelReached=PlayerPrefs.GetInt("levelReached",1);

        LevelButtons = GameObject.FindGameObjectsWithTag("LevelLoaderButton");
        for (int i = 0; i < levelReached; i++)
        {
            LevelButtons[i].GetComponent<Button>().interactable = true;
            LevelButtons[i].GetComponent<Image>().enabled=false;
        }
    }

    public void LoadScene(int BuildIndex)
    {
        SceneManager.LoadScene(BuildIndex);
    }
}
