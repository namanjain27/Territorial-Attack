using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlVolume : MonoBehaviour
{
    //public AudioSource[] Audio; // our audio to be played
    public float audioVolume  ;
    public AudioSource Audio;
    //public GameObject cam;
    public GameObject Coins;
    public Slider vol_slider;
    int presentScene;
    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < Audio.Length; i++)
        {
            Audio[i].volume = PlayerPrefs.GetFloat("Volume)");
        }*/
        //if (presentScene > 1) audioVolume =0.4f;
        //if (presentScene == 1) audioVolume =0.8f;
        presentScene = SceneManager.GetActiveScene().buildIndex;
        if (presentScene == 0 || presentScene >= 6) Coins = GameObject.FindGameObjectWithTag("CoinCount");
    }
    // Update is called once per frame
    void Update()
    {
        /*for (int i = 0; i < Audio.Length; i++)
        {
             Audio[i].volume = audioVolume;
        }*/
        
        Audio.volume = audioVolume;
        if(presentScene==0)
        {
            Coins.GetComponent<Text>().text = PlayerPrefs.GetInt("totalCoins").ToString();
        }
        else if (presentScene>=6) Coins.GetComponent<Text>().text = PlayerPrefs.GetInt("totalCoins").ToString();
    }

    public void control_vol(){
        audioVolume = vol_slider.value;
    }




    /*public void updateVolume(float volume)
    {
        audioVolume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
    public void Enable()
    {
        cam.GetComponent<AudioSource>().enabled = true;
    }*/
}
