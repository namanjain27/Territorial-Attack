using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninja : MonoBehaviour
{
    public GameObject hero;
    public float timer = 2f;
    public bool ready = true;
   // public Animator animator;

   /* IEnumerator jump(){
        hero.GetComponent<EnemyMovement>().enabled = false;
        animator.Play("ninja jump");
        yield return new WaitForSeconds(1.15f);
        hero.GetComponent<EnemyMovement>().enabled = true;
    }*/

    IEnumerator fast(){
        ready = false;
        hero.GetComponent<EnemyMovement>().speed = 1.6f;
        yield return new WaitForSeconds(2);
        timer = 2f;
        ready = true;
    }
   void Update(){
       if(hero.GetComponent<EnemyMovement>().enabled == true){
         //  StartCoroutine(jump());
        timer -= Time.deltaTime;
        if(timer <= 0) StartCoroutine(fast());
        if(ready){
            hero.GetComponent<EnemyMovement>().speed = 1f;
        }
       }
   }
}
