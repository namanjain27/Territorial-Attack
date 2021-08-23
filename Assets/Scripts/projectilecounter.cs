using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class projectilecounter : MonoBehaviour
{
    public DisableEnable inital;
    public Shoot current;
    public Text ball ;
    public Text shoe;
    public Text stone;
    public GameObject ballcount;
    public GameObject shoecount;
    public GameObject stonecount;
    int countball=0;
    int countshoe = 0;
    int countstone = 0;

    int presentScene;

    void Start()
    {
        presentScene = SceneManager.GetActiveScene().buildIndex;
        inital = GameObject.FindGameObjectWithTag("Target").GetComponent<DisableEnable>();
        if(presentScene==2)
        {
            current = GameObject.FindGameObjectWithTag("Target").transform.GetChild(4).gameObject.GetComponent<Shoot>();
        }
        else     current = GameObject.FindGameObjectWithTag("Target").transform.GetChild(1).gameObject.GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        countball= inital.ball - current.count1;
        ball.text =countball.ToString();
        if(countball==0) ballcount.SetActive(false);
        else if (countball >0) ballcount.SetActive(true);

        countshoe = inital.shoe - current.count2;
        shoe.text = countshoe.ToString();
        if(countshoe==0) shoecount.SetActive(false);
        else if (countshoe > 0) shoecount.SetActive(true);

        countstone = inital.stone - current.count3;
        stone.text = countstone.ToString();
        if(countstone==0) stonecount.SetActive(false);
        else if (countstone > 0) stonecount.SetActive(true);
    }
}
