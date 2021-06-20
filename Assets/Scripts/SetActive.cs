using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    private bool bool1 = false;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void Active()
    {
        if (bool1)
        {
            gameObject.SetActive(false);
            bool1 = false;
        }
        else
        {
            gameObject.SetActive(true);
            bool1 = true;
        }
    }
}
