using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PowerupController : MonoBehaviour
{
    //Defining powerups
    public GameObject healthPotion;
    public GameObject hammer;
    public GameObject shield;
    public GameObject tracer;
    public int presentScene;
    public Player player;
    //Defining counter variables
    int HP_cost=4;
    int H_cost=8;
    int S_cost=6;
    int L_cost=3;
    public int hit;


    void Start()
    {
        presentScene = SceneManager.GetActiveScene().buildIndex;
        hit = player.Hits;
        deactivate(tracer);
        deactivate(healthPotion);
        deactivate(hammer);
        deactivate(shield);
    }

    void Update()
    {
        hit = player.Hits;

        if(player.currentHealth <= 0)
        {
            deactivate(tracer);
            deactivate(healthPotion);
            deactivate(hammer);
            deactivate(shield);
        }
        //Activating buttons at desired hits
        else
    {   
        if(presentScene>=7)
        {
            healthPotion.SetActive(true);
            if (hit >= HP_cost) activate(healthPotion);
            if (hit < HP_cost) deactivate(healthPotion);
        }
        else healthPotion.SetActive(false);
        if(presentScene>=5)
        {
            tracer.SetActive(true);
            if (hit >= L_cost) activate(tracer);
            if (hit < L_cost) deactivate(tracer);
        }
        else tracer.SetActive(false);
        if(presentScene>=9)
        {
            shield.SetActive(true);
            if (hit >= S_cost) activate(shield);
            if (hit < S_cost) deactivate(shield);
        }
        else shield.SetActive(false);
        if(presentScene>=10)
        {
            hammer.SetActive(true);
            if (hit >= H_cost) activate(hammer);
            if (hit < H_cost) deactivate(hammer);
        }
        else hammer.SetActive(false);
    }
    }

    void activate(GameObject thing)
    {
        thing.GetComponent<Button>().interactable = true;
        var temp = thing.GetComponent<Image>().color;
        temp.a = 1f;
        thing.GetComponent<Image>().color = temp;
        //thing.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = new Color(129, 56, 255, 255);
        //temp1.a = 1f;
        //thing.transform.GetChild(0).gameObject.GetComponent<Text>().color = temp1;
    }

    void deactivate(GameObject thing)
    {
        thing.GetComponent<Button>().interactable = false;
        var temp = thing.GetComponent<Image>().color;
        temp.a = 0.4f;
        thing.GetComponent<Image>().color = temp;
        //thing.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = new Color(242, 56, 255, 5);
        //temp1.a = 0.4f;
        //thing.transform.GetChild(0).gameObject.GetComponent<Text>().color = temp1;
    }

    /* public void HammerAudio()
    {
        hammer.GetComponent<AudioSource>().enabled = true;
        hammer.GetComponent<AudioSource>().volume = 0.5f;
    }*/

    public void HealthPotionAudio()
    {
        healthPotion.GetComponent<AudioSource>().enabled = true;
        healthPotion.GetComponent<AudioSource>().volume = 0.5f;
    }

    public void ShieldAudio()
    {
        shield.GetComponent<AudioSource>().enabled = true;
        shield.GetComponent<AudioSource>().volume = 0.5f;
    }
}
