using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public GameObject bossShield;
    
    public GameObject Boss;
    bool timed = true;
    public int CollidedCount=0;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hammer" || collision.gameObject.tag == "Enemy3" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy1")
        {
            CollidedCount += 1;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator ready(){
        timed = false;
        Boss.GetComponent<EnemyMovement>().enabled= false;
        Boss.GetComponent<EnemyShoot>().delayStart = 0.1f;
        Boss.GetComponent<EnemyShoot>().delayEnd = 0.8f;
        bossShield.SetActive(false);
        Boss.transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>().enabled = false;
        CollidedCount = 0;
        yield return new WaitForSeconds(2);
        Boss.GetComponent<EnemyMovement>().enabled = true;
        timed = true;
    }
    
    void Update()
    {
        if(timed){
            if(Boss.GetComponent<EnemyMovement>().enabled==true)
            {
                 bossShield.SetActive(true);
                 Boss.transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>().enabled = true;
                 Boss.GetComponent<EnemyShoot>().delayStart = 2f;
                 Boss.GetComponent<EnemyShoot>().delayEnd = 3f;
            }
        }
        if (CollidedCount == 4){
            StartCoroutine(ready());
        }
        if(Boss.GetComponent<Enemy>().maxHealth == 0){timed = false;}
    }
}