using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collided : MonoBehaviour
{
    public bool bool1 = false;
    public bool bool2 = false;
    public bool bool3 = false;
    public void False()
    {
        bool1 = false;
        bool2 = false;
        bool3 = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy1")
        {
            bool1 = true;
        }
        if (collision.gameObject.tag == "Enemy2")
        {
            bool2 = true;
        }
        if (collision.gameObject.tag == "Enemy3")
        {
            bool3 = true;
        }
    }

    

}
