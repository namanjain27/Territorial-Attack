using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject projectile;

    public void DestroyGameObject()
    {
        DestroyImmediate(gameObject, true);
    }
}
