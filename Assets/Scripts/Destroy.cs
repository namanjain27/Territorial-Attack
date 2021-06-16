using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    GameObject other;
    bool m_collided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_collided = true;
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if(m_collided)
        {
            DestroyGameObject();
        }
        m_collided = false;
    }
}
