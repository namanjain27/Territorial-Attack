using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PowerupController : MonoBehaviour
{
    //Defining powerups
    public GameObject healthPotion;
    public GameObject hammer;
    public GameObject shield;
    public GameObject tracer;
    public int presentScene;

    //Defining counter variables
    int HP_cost=4;
    int H_cost=8;
    int S_cost=6;
    int L_cost=3;
    public int hit;

    public Player player;

    void Start()
    {
        presentScene = SceneManager.GetActiveScene().buildIndex;
        hit = player.Hits;
        healthPotion.SetActive(false);
        hammer.SetActive(false);
        shield.SetActive(false);
        tracer.SetActive(false);
    }

    void Update()
    {
        hit = player.Hits;

        //Activating buttons at desired hits
        if(presentScene>=7)
        {
            if (hit >= HP_cost) healthPotion.SetActive(true);
            if (hit < HP_cost) healthPotion.SetActive(false);
        }
        else healthPotion.SetActive(false);
        if(presentScene>=5)
        {
            if (hit >= L_cost) tracer.SetActive(true);
            if (hit < L_cost) tracer.SetActive(false);
        }
        else tracer.SetActive(false);
        if(presentScene>=9)
        {
            if (hit >= S_cost) shield.SetActive(true);
            if (hit < S_cost) shield.SetActive(false);
        }
        else shield.SetActive(false);
        if(presentScene>=10)
        {
            if (hit >= H_cost) hammer.SetActive(true);
            if (hit < H_cost) hammer.SetActive(false);
        }
        else hammer.SetActive(false);
    }
     public void HammerAudio()
    {
        hammer.GetComponent<AudioSource>().enabled = true;
        hammer.GetComponent<AudioSource>().volume = 0.5f;
    }

    public void HealthPotionAudio()
    {
        hammer.GetComponent<AudioSource>().volume = 0f;
        healthPotion.GetComponent<AudioSource>().enabled = true;
        healthPotion.GetComponent<AudioSource>().volume = 0.5f;
    }

    public void ShieldAudio()
    {
        hammer.GetComponent<AudioSource>().volume = 0f;
        shield.GetComponent<AudioSource>().enabled = true;
        shield.GetComponent<AudioSource>().volume = 0.5f;
    }
}
