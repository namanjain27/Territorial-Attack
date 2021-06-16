using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject Stone1;
    public GameObject Stone2;
    public GameObject Stone3;

    private float LaunchForce;

    public DisableEnable disableEnable;
    // Start is called before the first frame update
    // Update is called once per frame
    public void AdjustForce(float newforce)
    {


        GameObject character1 = GameObject.Find("Character1");
        DisableEnable disableEnable = character1.GetComponent<DisableEnable>();
        LaunchForce = newforce;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if(disableEnable.appears1) Shooting(Stone1);
            else if (disableEnable.appears2) Shooting(Stone2);
            else if (disableEnable.appears3) Shooting(Stone3);

        }
    }

     void Shooting(GameObject Object1)
    {
        GameObject Stoneclone = Instantiate(Object1, transform.position, transform.rotation);

        Stoneclone.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
        disableEnable.disappear();

    }
}
