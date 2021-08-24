using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableEnable : MonoBehaviour
{
    //the n number of objects which we want to shoot
    public GameObject[] Projectile;
    //public GameObject volume;
    public GameObject HammerButton;
    public int ball=3;
    public int shoe=2;
    public int stone=2;

    public float delay = 2f;

    public Shoot shoot;

    public bool activated=false;


    //the bools corresponding to each object depicting it's appearence/disappearence
    public bool[] active;

    public GameObject TennisBall;
    public GameObject stones;
    public GameObject shoes;

    public Player GameEnd;

    int presentScene;

    int end1=0, end2=0, end3=0;
    int ballIncreased, shoeIncreased, stoneIncreased;
    float random;
    //disappearing each object in starting
    public void Start()
    {
        presentScene = SceneManager.GetActiveScene().buildIndex;
        if(presentScene>=6)
        {
            ballIncreased = PlayerPrefs.GetInt("RemainingBall");
            shoeIncreased = PlayerPrefs.GetInt("RemainingShoe");
            stoneIncreased = PlayerPrefs.GetInt("RemainingStone"); 

            ball += ballIncreased;
            shoe += shoeIncreased;
            stone += stoneIncreased;

            PlayerPrefs.SetInt("RemainingStone", 0);
            PlayerPrefs.SetInt("RemainingShoe", 0);
            PlayerPrefs.SetInt("RemainingBall", 0);
            PlayerPrefs.Save();           
        }
        for (int i=0;i<3;i++)
        {
            Projectile[i].SetActive(false);
        }
        if (ball > 0) TennisBall.SetActive(true);
        if (shoe > 0) shoes.SetActive(true);
        if (stone > 0) stones.SetActive(true);
    }

    public void Disappear(bool activated,int i)
    {
        for(int k=0;k<3;k++)
        {
            Projectile[k].SetActive(false);
            active[k] = false;
        }
        Projectile[i].SetActive(activated);
        active[i] = activated;
    }

    public void Inactive()
    {
        Disappear(false, 1);
    }

    public void Update()
    {
        random = Random.Range(0, 1);
        if (ball > 0) TennisBall.SetActive(true);
        if (shoe > 0) shoes.SetActive(true);
        if (stone > 0) stones.SetActive(true);
        if (HammerButton.activeSelf) Disappear(false, 1);
        else
        {
            if (shoot.count1 == ball)
            {
                TennisBall.SetActive(false);
                Projectile[0].SetActive(false);
                active[0] = false;
                if (end1 == 0)
                {
                    if (shoot.count2 < shoe && shoot.count3 < stone)
                    {
                        if (random < 0.5) Disappear(true, 1);
                        else Disappear(true, 2);
                        end1++;
                    }
                    else if (shoot.count2 >= shoe && shoot.count3 < stone)
                    {
                        Disappear(true, 2);
                        end1++;
                    }
                    else if (shoot.count2 < shoe && shoot.count3 >= stone)
                    {
                        Disappear(true, 1);
                        end1++;
                    }
                }
            }
            if (shoot.count2 == shoe)
            {
                shoes.SetActive(false);
                Projectile[1].SetActive(false);
                active[1] = false;
                if (end2 == 0)
                {
                    if (shoot.count1 < ball && shoot.count3 < stone)
                    {
                        if (random < 0.5) Disappear(true, 0);
                        else Disappear(true, 2);
                        end2++;
                    }
                    else if (shoot.count1 >= ball && shoot.count3 < stone)
                    {
                        Disappear(true, 2);
                        end2++;
                    }
                    else if (shoot.count1 < ball && shoot.count3 >= stone)
                    {
                        Disappear(true, 0);
                        end2++;
                    }
                }
            }
            if (shoot.count3 == stone)
            {
                stones.SetActive(false);
                Projectile[2].SetActive(false);
                active[2] = false;
                if (end3 == 0)
                {
                    if (shoot.count2 < shoe && shoot.count1 < ball)
                    {
                        if (random < 0.5) Disappear(true, 1);
                        else Disappear(true, 0);
                        end3++;
                    }
                    else if (shoot.count2 >= shoe && shoot.count1 < ball)
                    {
                        Disappear(true, 0);
                        end3++;
                    }
                    else if (shoot.count2 < shoe && shoot.count1 >= ball)
                    {
                        Disappear(true, 1);
                        end3++;
                    }
                }
            }
        }
        /*if (shoot.count1 >= ball && shoot.count2 >= shoe && shoot.count3 >= stone)
        {
            delay -= Time.deltaTime;
            if (delay < 0) GameEnd.DestroyObject(); 
        }*/
    }
    public void Inactive1()
    {
        if (HammerButton.activeSelf)
        {
            Disappear(false,1);
            return;
        }
        Disappear(true, 0);
    }

    public void Inactive2()
    {
        if (HammerButton.activeSelf)
        {
            Disappear(false,1);
            return;
        }
        Disappear(true, 1);
    }


    public void Inactive3()
    {
        if (HammerButton.activeSelf)
        {
            Disappear(false,1);
            return;
        }
        Disappear(true, 2);
    }
}
