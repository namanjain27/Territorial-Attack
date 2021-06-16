using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnable : MonoBehaviour
{
    //the n number of objects which we want to shoot
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;

    //the bools corresponding to each object depicting it's appearence/disappearence
    public bool appears1=false;
    public bool appears2 = false;
    public bool appears3 = false;

    //disappearing each object in starting
     void Start()
    {
        Object1.SetActive(false);
        Object2.SetActive(false);
        Object3.SetActive(false);
    }

    public void disappear()
    {
        Object1.SetActive(false);
        Object2.SetActive(false);
        Object3.SetActive(false);
    }

    public void Inactive1()
    {
        if (!appears1)   //check if object1 is already present
        {
          if(!appears2)   //check if object2 is already present
            {
                if(!appears3)  //check if object3 is already present
                {
                    Object1.SetActive(true);
                    appears1 = true;
                }
                else
                {
                    Object3.SetActive(false);
                    appears3 = false;
                    Object1.SetActive(true);
                    appears1 = true;
                }
            }
          else
            {
                Object2.SetActive(false);
                appears2 = false;
                if (!appears3)  
                {
                    Object1.SetActive(true);
                    appears1 = true;
                }
                else
                {
                    Object3.SetActive(false);
                    appears3 = false;
                    Object1.SetActive(true);
                    appears1 = true;
                }
            }
        }
        else
        {
            Object1.SetActive(false);
            appears1 = false;
            if (!appears2)   
            {
                if (appears3)  
                {
                    Object3.SetActive(false);
                    appears3 = false;
                }             
             }
            else
            {
                Object2.SetActive(false);
                appears2 = false;
                if (appears3)  
                {
                    Object3.SetActive(false);
                    appears3 = false;
                }

            }
        }
    }

    public void Inactive2()
    {
        if (!appears2)   //check if object1 is already present
        {
            if (!appears1)   //check if object2 is already present
            {
                if (!appears3)  //check if object3 is already present
                {
                    Object2.SetActive(true);
                    appears2 = true;
                }
                else
                {
                    Object3.SetActive(false);
                    appears3 = false;
                    Object2.SetActive(true);
                    appears2 = true;
                }
            }
            else
            {
                Object1.SetActive(false);
                appears1 = false;
                if (!appears3)
                {
                    Object2.SetActive(true);
                    appears2 = true;
                }
                else
                {
                    Object3.SetActive(false);
                    appears3 = false;
                    Object2.SetActive(true);
                    appears2 = true;
                }
            }
        }
        else
        {
            Object2.SetActive(false);
            appears2 = false;
            if (!appears1)
            {
                if (appears3)
                {
                    Object3.SetActive(false);
                    appears3 = false;
                }
            }
            else
            {
                Object1.SetActive(false);
                appears1 = false;
                if (appears3)
                {
                    Object3.SetActive(false);
                    appears3 = false;
                }

            }
        }
    }

    public void Inactive3()
    {
        if (!appears3)   //check if object1 is already present
        {
            if (!appears2)   //check if object2 is already present
            {
                if (!appears1)  //check if object3 is already present
                {
                    Object3.SetActive(true);
                    appears3 = true;
                }
                else
                {
                    Object1.SetActive(false);
                    appears1 = false;
                    Object3.SetActive(true);
                    appears3 = true;
                }
            }
            else
            {
                Object2.SetActive(false);
                appears2 = false;
                if (!appears1)
                {
                    Object3.SetActive(true);
                    appears3 = true;
                }
                else
                {
                    Object1.SetActive(false);
                    appears1 = false;
                    Object3.SetActive(true);
                    appears3 = true;
                }
            }
        }
        else
        {
            Object3.SetActive(false);
            appears3 = false;
            if (!appears2)
            {
                if (appears1)
                {
                    Object1.SetActive(false);
                    appears1 = false;
                }
            }
            else
            {
                Object2.SetActive(false);
                appears2 = false;
                if (appears1)
                {
                    Object1.SetActive(false);
                    appears1 = false;
                }

            }
        }
    }
}
