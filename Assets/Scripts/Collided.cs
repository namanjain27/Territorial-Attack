using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collided : MonoBehaviour
{
    public int i = 0;
    public float HitCount = 0f;
    public ParticleSystem enemythunder;
    //public GameObject Enemy;
    //public Vector3[] changes;
    int presentScene;
    //int t=-1;
    
    public void HP_click(){
        HitCount -= 4;
    }

    public void H_click(){
        HitCount -= 8;
    }

    public void S_click(){
        HitCount -= 6;
    }

    public void L_click(){
        HitCount -= 3;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Enemy1")
        {
            i = 1;
        }
        else if (collision.gameObject.tag == "Enemy2")
        {
            i = 2;
        }
        else if (collision.gameObject.tag == "Enemy3")
        {
            i = 3;
        }
        else if (collision.gameObject.tag == "Hammer")
        {
            enemythunder.Play();
            i = 7;
        }

        if (i != 0)
        {
            float x = Random.Range(0f, 25.5f);
            float y = Random.Range(-6.5f, 3f);
            if(presentScene==1)
            {
                this.transform.Translate(x - this.transform.position.x, y - this.transform.position.y, 0, Space.Self);
                //t += 1;
                //Enemy.transform.Translate(changes[t], Space.Self);
            }
        }

        if (i!=0)HitCount++;

    }
    void Start()
    {
        presentScene = SceneManager.GetActiveScene().buildIndex;
    }
}
