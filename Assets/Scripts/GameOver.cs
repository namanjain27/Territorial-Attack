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
