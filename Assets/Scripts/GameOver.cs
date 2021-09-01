using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Hit;
    public GameObject slider;
    public GameObject shoot;
    public GameObject pause;
    public GameObject MainPlayer;

    public int presentScene;

    public projectilecounter counter;

    private void Start()
    {
        presentScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void RestartButton ()
    {
        pause.SetActive(false);
        pause.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Hit.SetActive(true);
        slider.SetActive(true);
        shoot.SetActive(true);
    }

    public void MainMenuButton ()
    {
        MainPlayer.GetComponent<Player>().SaveCoins();
        SceneManager.LoadScene(0);
        //StartCoroutine(MainMenu(1));
    }

    public void ExitButton ()
    {
        MainPlayer.GetComponent<Player>().SaveCoins();
        Application.Quit();
        //StartCoroutine(ExitGame(1));
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Hit.SetActive(true);
        slider.SetActive(true);
        shoot.SetActive(true);
    }

    /*IEnumerator ExitGame(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        Application.Quit();
    }

    IEnumerator MainMenu(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        SceneManager.LoadScene(0);
    }*/
}
