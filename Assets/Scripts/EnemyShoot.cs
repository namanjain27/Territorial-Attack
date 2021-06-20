using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShoot : MonoBehaviour
{
    public GameObject[] projectile;
    public GameObject character;

    public Transform launchsite;

    float flag = 0;
    float countdown;
    float random;

    public float delay = 0f;
    public float range;
    public float time = 1f;
    public float gravityy = 10;

    float velocityX;
    float velocityY;


    int a;
    int[] table = { 33, 33, 34 };

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy1" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy3")
        {
            flag = 1;
        }
    }
    void Start()
    {
        countdown = delay;

    }

    // Update is called once per frame
    void Update()

    {
        if (flag == 1)
        {
            random = Random.Range(0, 100);      //selcting random number 
            for (int i = 0; i < 3; i++)
            {                                   //selecting projectile to throw 
                if (random < table[i])
                {
                    a = i;
                    break;
                }
                else
                {
                    random -= table[i];
                }
            }
        }
        if (flag == 1)
        {
            countdown -= Time.deltaTime;
        }
        if (flag == 1 && countdown < 0f)
        {
            fire(projectile[a]);
            flag = 0;
            countdown = delay;
        }
        range = Vector2.Distance(character.transform.position, launchsite.transform.position);
        velocityX = range / time;
        velocityY = gravityy * 10 * time;
    }
    void fire(GameObject weapon)
    {
        GameObject attackerinst = Instantiate(weapon, launchsite.position, Quaternion.identity);
        attackerinst.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocityX, velocityY);

    }
}