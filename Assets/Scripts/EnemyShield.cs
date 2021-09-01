using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShield : MonoBehaviour
{
    public float time;
    public GameObject Shield;
    public GameObject Enemy;
    int presentScene;

    void Start()
    {
        presentScene = SceneManager.GetActiveScene().buildIndex;
        if (presentScene < 10) Shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy.GetComponent<EnemyMovement>().enabled)
        {
            if (time >= 0) time -= Time.deltaTime;
            if (time < 0) Shield.SetActive(false);
        }        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hammer" || collision.gameObject.tag == "Enemy3" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy1")
        {
            Destroy(collision.gameObject);
        }
    }
}
