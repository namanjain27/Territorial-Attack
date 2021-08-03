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
        int levelReached=PlayerPrefs.GetInt("levelReached",1);

        LevelButtons = GameObject.FindGameObjectsWithTag("LevelLoaderButton");
        for (int i = 0; i < levelReached; i++)
        {
            LevelButtons[i].GetComponent<Button>().interactable = true;
            LevelButtons[i].GetComponent<Image>().enabled = false;
        }
        int totalCoins = PlayerPrefs.GetInt("totalCoins", 0);

        int highScore1 = PlayerPrefs.GetInt("highScore1", 0);
        int highScore2 = PlayerPrefs.GetInt("highScore2", 0);
        int highScore3 = PlayerPrefs.GetInt("highScore3", 0);
        int highScore4 = PlayerPrefs.GetInt("highScore4", 0);
        int highScore5 = PlayerPrefs.GetInt("highScore5", 0);
        int highScore6 = PlayerPrefs.GetInt("highScore6", 0);
        int highScore7 = PlayerPrefs.GetInt("highScore7", 0);
        int highScore8 = PlayerPrefs.GetInt("highScore8", 0);
        int highScore9 = PlayerPrefs.GetInt("highScore9", 0);
        int highScore10 = PlayerPrefs.GetInt("highScore10", 0);
        int highScore11 = PlayerPrefs.GetInt("highScore11", 0);
        int highScore12 = PlayerPrefs.GetInt("highScore12", 0);
    }

    public void LoadScene(int BuildIndex)
    {
        SceneManager.LoadScene(BuildIndex);
    }
}
