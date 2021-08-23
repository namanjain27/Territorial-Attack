using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlVolume : MonoBehaviour
{
    public AudioSource Audio; // our audio to be played
    public float audioVolume = 0.01f;
    public GameObject cam;
    public GameObject Coins;
    int presentScene;
    // Start is called before the first frame update
    void Start()
    {
        presentScene = SceneManager.GetActiveScene().buildIndex;
        if (presentScene == 0 || presentScene >= 6) Coins = GameObject.FindGameObjectWithTag("CoinCount");
    }
    // Update is called once per frame
    void Update()
    {
        Audio.volume = audioVolume;
        if(presentScene==0)
        {
            Coins.GetComponent<Text>().text = PlayerPrefs.GetInt("totalCoins").ToString();
        }
        else if (presentScene>=6) Coins.GetComponent<Text>().text = PlayerPrefs.GetInt("totalCoins").ToString();
    }

    public void updateVolume(float volume)
    {
        audioVolume = volume;
    }
    public void Enable()
    {
        cam.GetComponent<AudioSource>().enabled = true;
    }
}
