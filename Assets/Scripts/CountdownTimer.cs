using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public int secondsLeft;
    public int counter = 0;
    public int number;
    public GameObject Player;
    public bool takingAway = false;

    //public GameObject Stationary;
    //public GameObject Enemy;
    //public GameObject armored;
    //public GameObject[] enemyclone;
    public GameObject text;
    public GameObject timer;
    public int time_ul= 18;
    public int time_ll = 9;
    int i=0;

    void Start()
    {
        //secondsLeft = Random.Range(time_ll,time_ul);
        text.GetComponent<Text>().text = "00:" + secondsLeft;
        Player = GameObject.FindGameObjectWithTag("Target");
        //enemy_order = new GameObject[number];
        /*for(i=0;i<number;i++)
        {
            //clonedEnemy[i]= Instantiate(Enemy, Stationary.transform.position, Stationary.transform.rotation);
            enemyclone[i] = Instantiate(enemy_order[i], Stationary.transform.position, Stationary.transform.rotation);


            enemyclone[i].GetComponent<EnemyShoot>().enabled = false;
            enemyclone[i].GetComponent<EnemyMovement>().enabled = false;
            enemyclone[i].GetComponent<CapsuleCollider2D>().enabled = false;
            /*clonedEnemy[i].transform.GetChild(3).gameObject.GetComponent<ParticleSystem>().Stop();
            clonedEnemy[i].transform.GetChild(3).gameObject.GetComponent<CircleCollider2D>().enabled = false;
            clonedEnemy[i].transform.GetChild(3).gameObject.GetComponent<AudioSource>().enabled = false;*/
        
        //i = 0;
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
        Player.GetComponent<Player>().enemy_order[i].GetComponent<EnemyMovement>().enabled = true;
        Player.GetComponent<Player>().enemy_order[i].GetComponent<EnemyShoot>().enabled = true;
        Player.GetComponent<Player>().enemy_order[i].GetComponent<CapsuleCollider2D>().enabled = true;
        /*clonedEnemy[i].transform.GetChild(3).gameObject.GetComponent<ParticleSystem>().Play();
        clonedEnemy[i].transform.GetChild(3).gameObject.GetComponent<CircleCollider2D>().enabled = true;
        clonedEnemy[i].transform.GetChild(3).gameObject.GetComponent<AudioSource>().enabled=true;*/
        secondsLeft = Random.Range(time_ll,time_ul);
        counter++;
        i++;
        if (counter >= number)
        {
            timer.SetActive(false);
            return;
        }        
    }
    
}

