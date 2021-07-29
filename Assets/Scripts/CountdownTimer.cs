using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public int secondsLeft;
    public int counter = 0;
    public int number;
    int i=0;

    public bool takingAway = false;

    public GameObject Stationary;
    public GameObject Enemy;
    public GameObject text;
    public GameObject Counter;
    public GameObject[] clonedEnemy;

    void Start()
    {
        secondsLeft = Random.Range(13,17);
        text.GetComponent<Text>().text = "00:" + secondsLeft;
        for(i=0;i<number;i++)
        {
            clonedEnemy[i]= Instantiate(Enemy, Stationary.transform.position, Stationary.transform.rotation);
            clonedEnemy[i].GetComponent<EnemyShoot>().enabled = false;
            clonedEnemy[i].GetComponent<EnemyMovement>().enabled = false;
            clonedEnemy[i].GetComponent<CapsuleCollider2D>().enabled = false;
            /*clonedEnemy[i].transform.GetChild(3).gameObject.GetComponent<ParticleSystem>().Stop();
            clonedEnemy[i].transform.GetChild(3).gameObject.GetComponent<CircleCollider2D>().enabled = false;
            clonedEnemy[i].transform.GetChild(3).gameObject.GetComponent<AudioSource>().enabled = false;*/
        }
        i = 0;
    }

    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            text.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else
        {
            text.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        takingAway = false;
        if (secondsLeft <= 0)
        {
            if(number>0)
            {
                CloneEnemy();
            }            
        }    
    }

    public void CloneEnemy()
    {
        clonedEnemy[i].GetComponent<EnemyShoot>().enabled = true;
        clonedEnemy[i].GetComponent<EnemyMovement>().enabled = true;
        clonedEnemy[i].GetComponent<CapsuleCollider2D>().enabled = true;
        /*clonedEnemy[i].transform.GetChild(3).gameObject.GetComponent<ParticleSystem>().Play();
        clonedEnemy[i].transform.GetChild(3).gameObject.GetComponent<CircleCollider2D>().enabled = true;
        clonedEnemy[i].transform.GetChild(3).gameObject.GetComponent<AudioSource>().enabled=true;*/
        secondsLeft = Random.Range(10, 20);
        counter++;
        i++;
        if (counter >= number)
        {
            Counter.SetActive(false);
            return;
        }        
    }
}
