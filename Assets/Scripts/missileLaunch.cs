using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileLaunch : MonoBehaviour
{
    public GameObject Missile;
    public ParticleSystem AcidRain;
    public bool fired = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(Missile, transform.position, transform.rotation);
            fired = true;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            AcidRain.Play();
        }

    }
}
