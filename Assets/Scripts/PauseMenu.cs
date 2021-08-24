using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseUI;
    public Slider powerslider;
    public Button[] buttons;

    public GameObject Error;

    public GameObject MainPlayer;

    public GameObject pause;

    public int coins;

    int presentScene;
    public GameObject[] Powerups;

    public GameObject[] Stores;

    public GameObject Store;


    //float time = 1;

    void Start()
    {
        presentScene = SceneManager.GetActiveScene().buildIndex;
        if (presentScene >= 5) Powerups[0].SetActive(true);
        if (presentScene >= 7) Powerups[1].SetActive(true);
        if (presentScene >= 9) Powerups[2].SetActive(true);
        if (presentScene >= 10) Powerups[3].SetActive(true);        
        coins = PlayerPrefs.GetInt("totalCoins");
        /*if (presentScene==2)
        {
            Pause();
            PauseUI.SetActive(false);
        }*/
        if(presentScene>=6)  Pause();
        PauseUI.SetActive(false);
        MainPlayer = GameObject.FindGameObjectWithTag("Target");
    }
    // Update is called once per frame
    void Update()
    {if(Store.activeSelf)
        {
            coins = PlayerPrefs.GetInt("totalCoins");
            if (coins < 5)
            {
                Stores[0].GetComponent<Button>().enabled = false;
                var tempColor = Stores[0].GetComponent<Image>().color;
                tempColor.a = 0.2f;
                Stores[0].GetComponent<Image>().color = tempColor;
            }
            else if (coins >= 5)
            {
                Stores[0].GetComponent<Button>().enabled = true;
                var tempColor = Stores[0].GetComponent<Image>().color;
                tempColor.a = 0f;
                Stores[0].GetComponent<Image>().color = tempColor;
            }

            if (coins < 10)
            {
                Stores[1].GetComponent<Button>().enabled = false;
                var tempColor = Stores[1].GetComponent<Image>().color;
                tempColor.a = 0.2f;
                Stores[1].GetComponent<Image>().color = tempColor;
            }
            else if (coins >= 10)
            {
                Stores[1].GetComponent<Button>().enabled = true;
                var tempColor = Stores[1].GetComponent<Image>().color;
                tempColor.a = 0f;
                Stores[1].GetComponent<Image>().color = tempColor;
            }

            if (coins < 15)
            {
                Stores[2].GetComponent<Button>().enabled = false;
                var tempColor = Stores[2].GetComponent<Image>().color;
                tempColor.a = 0.2f;
                Stores[2].GetComponent<Image>().color = tempColor;
            }
            else if (coins >= 15)
            {
                Stores[2].GetComponent<Button>().enabled = true;
                var tempColor = Stores[2].GetComponent<Image>().color;
                tempColor.a = 0f;
                Stores[2].GetComponent<Image>().color = tempColor;
            }
        }        
        /*if (Error.activeSelf)
        {
            while (time > 0) time -= Time.deltaTime;
            Error.SetActive(false);
        }*/
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pause.SetActive(false);
        pause.SetActive(true);
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        MainPlayer.GetComponent<TouchForce>().enabled = true;
        powerslider.interactable = true;
        for (int i = 0; i < 9; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void Pause()
    {
        pause.SetActive(false);
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        MainPlayer.GetComponent<TouchForce>().enabled = false;
        powerslider.interactable = false;
        for(int i=0;i<9;i++)
        {
            buttons[i].interactable = false;
        }
    }

    public void interact()
    {
        for (int i = 0; i < 9; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void Ball()
    {
        /*if (coins<5)
        {
            Error.SetActive(true);
            time = 1f;
            return;
        }*/
        if (Stores[0].GetComponent<Button>().enabled == false) return;
        MainPlayer.GetComponent<DisableEnable>().ball += 5;
        coins = coins - 5;
        PlayerPrefs.SetInt("totalCoins", coins);
        PlayerPrefs.SetInt("RemainingBall", MainPlayer.GetComponent<DisableEnable>().ball - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count1);
        PlayerPrefs.Save();
    }

    public void Shoe()
    {
        /*if (coins < 10)
        {
            Error.SetActive(true);
            time = 1f;
            return;
        }*/
        if (Stores[1].GetComponent<Button>().enabled == false) return;
        MainPlayer.GetComponent<DisableEnable>().shoe += 5;
        coins = coins - 10;
        PlayerPrefs.SetInt("totalCoins", coins);
        PlayerPrefs.SetInt("RemainingShoe", MainPlayer.GetComponent<DisableEnable>().shoe - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count2);
        PlayerPrefs.Save();
    }

    public void Stone()
    {
        /*if (coins < 15)
        {
            Error.SetActive(true);
            time = 1f;
            return;
        }*/
        if (Stores[2].GetComponent<Button>().enabled == false) return;
        MainPlayer.GetComponent<DisableEnable>().stone += 5;
        coins = coins - 15;
        PlayerPrefs.SetInt("totalCoins", coins);
        PlayerPrefs.SetInt("RemainingStone", MainPlayer.GetComponent<DisableEnable>().stone - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count3);
        PlayerPrefs.Save();
    }
}
