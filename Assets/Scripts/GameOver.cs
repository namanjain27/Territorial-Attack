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

     void Start()
    {
        MainPlayer = GameObject.FindGameObjectWithTag("Target");
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
        SceneManager.LoadScene("mainMenu");
    }

    public void ExitButton ()
    {
        PlayerPrefs.SetInt("RemainingStone", MainPlayer.GetComponent<DisableEnable>().ball - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count1);
        PlayerPrefs.SetInt("RemainingShoe", MainPlayer.GetComponent<DisableEnable>().shoe - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count2);
        PlayerPrefs.SetInt("RemainingBall", MainPlayer.GetComponent<DisableEnable>().stone - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count3);
        PlayerPrefs.Save();
        Application.Quit ();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Hit.SetActive(true);
        slider.SetActive(true);
        shoot.SetActive(true);
    }
}
