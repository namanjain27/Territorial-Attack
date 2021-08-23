using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject[] LevelButtons;
    //int level1HighScorePrefs, level2HighScorePrefs, level3HighScorePrefs, level4HighScorePrefs, level5HighScorePrefs, level6HighScorePrefs, level7HighScorePrefs, level8HighScorePrefs, level9HighScorePrefs, level10HighScorePrefs, level11HighScorePrefs, level12HighScorePrefs;
    // Start is called before the first frame update
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

        int RemainingBall = PlayerPrefs.GetInt("RemainingBall", 0);
        int RemainingShoe = PlayerPrefs.GetInt("RemainingShoe", 0);
        int RemainingStone = PlayerPrefs.GetInt("RemainingStone", 0);

    }

    public void LoadScene(int BuildIndex)
    {
        SceneManager.LoadScene(BuildIndex);
    }
}
