using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    public bool bool1 = false;
    public bool bool2 = false;
    public bool bool3 = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy1") bool1 = true;
        if (collision.gameObject.tag == "Enemy2") bool2 = true;
        if (collision.gameObject.tag == "Enemy3") bool3 = true;
    }


}