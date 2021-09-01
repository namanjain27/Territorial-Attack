
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerProjectile : MonoBehaviour
{
    //to check collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Shield") || collision.gameObject.CompareTag("ninja"))
        {
            Destroy();
        }
    }

    //destroy game object
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
