using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    // Update is called once per frame
    void Update()
    {
        countball= inital.ball - current.count1;
        ball.text =countball.ToString();
        if(countball==0)
        {
            ballcount.SetActive(false);
        }
        countshoe = inital.shoe - current.count2;
        shoe.text = countshoe.ToString();
        if(countshoe==0)
        {
            shoecount.SetActive(false);
        }
        countstone = inital.stone - current.count3;
        stone.text = countstone.ToString();
        if(countstone==0)
        {
            stonecount.SetActive(false);
        }
    }
}
