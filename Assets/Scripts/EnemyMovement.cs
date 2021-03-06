using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    int presentScene;
    float t = 0;
    public float TimeChange=1f;
    public float speedChange =0.2f;
    public GameObject Stationary;
    public GameObject Enemy;
    Vector3 move;
    public bool isWalking;
    Animator m_Animator;
    public Enemy enemy;
    public float timer;

    void Start()
    {
        presentScene = SceneManager.GetActiveScene().buildIndex;
        timer = TimeChange;
        if(presentScene>=10) TimeChange = 1.2f;
        m_Animator = GetComponent<Animator>();
        Stationary.transform.position = Enemy.transform.position;
        Stationary.transform.rotation = Enemy.transform.rotation;
        if(presentScene>=6) speed  = 1.5f;
        else speed  = 1.3f;
    }

    void FixedUpdate()
    {
        if(presentScene>=5)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                speed += speedChange;
                timer = TimeChange;
                if (gameObject.CompareTag("Enemy"))
                {
                    if(speed>3.5f) speed = 3.5f;
                }
                if (gameObject.CompareTag("ninja")){
                    speed = Random.Range(-1f, 3.8f);
                }
            }
        }
        if (gameObject.CompareTag("Boss"))
        {
            speedChange = 0.1f;
        }
        else if(presentScene==9 || presentScene==10 ) speedChange = 0.28f;
        else if(presentScene > 10) speedChange = 0.33f;
        else speedChange = 0.2f;
        t = -1;
        isWalking = !Mathf.Approximately(t, 0f);
        m_Animator.SetBool("IsWalking", isWalking);
        move.x = t;
        transform.Translate(move * Time.fixedDeltaTime * speed); 
    }
}
