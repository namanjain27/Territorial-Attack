using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject Stone1;
    public GameObject Stone2;
    public GameObject Stone3;

    public float LaunchForce;

    // Update is called once per frame
    public void AdjustForce(float newforce)
    {
        LaunchForce = newforce;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (GameObject.Find("Character1").GetComponent<DisableEnable>().appears1)
            {             
                Shooting(Stone1);

            }
            else if (GameObject.Find("Character1").GetComponent<DisableEnable>().appears2)
            {                
                Shooting(Stone2);
            }    
               
            else if (GameObject.Find("Character1").GetComponent<DisableEnable>().appears3)
            {
                Shooting(Stone3);
 
            }   
                
        }
    }

    void Shooting(GameObject other)
    {
        GameObject Stoneclone = Instantiate(other, transform.position, transform.rotation);

        Stoneclone.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
        GameObject.Find("Character1").GetComponent<DisableEnable>().Disappear();
    }
}
