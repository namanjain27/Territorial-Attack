using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    float t = 0;

    public float TimeChange=5f;
    public float speedChange=0.5f;

    public GameObject Stationary;
    public GameObject Enemy;

    Vector3 move;

    public bool isWalking;

    Animator m_Animator;

    public Enemy enemy;

    public float timer;

    void Start()
    {
        timer = TimeChange;
        m_Animator = GetComponent<Animator>();
        Stationary.transform.position = Enemy.transform.position;
        Stationary.transform.rotation = Enemy.transform.rotation;
    }

    void FixedUpdate()
    {
        speed = Random.Range(1.5f, 3.0f);
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            speed += speedChange;
            timer = TimeChange;
        }
        t = -1;
        isWalking = !Mathf.Approximately(t, 0f);
        m_Animator.SetBool("IsWalking", isWalking);
        move.x = t;
        transform.Translate(move * Time.fixedDeltaTime * speed); 
    }
}
