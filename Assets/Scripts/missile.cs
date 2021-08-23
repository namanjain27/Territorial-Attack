using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class missile : MonoBehaviour

{
    public Transform target;


    private Rigidbody2D rb;
    public float speed = 5f;
    public float firespeed = 100f;
    public float rotationSpeed = 0f;
    public float firerotationSpeed = 500f;
    public GameObject explositionEffect;
    float time = 1.5f;
    float countdown = 0f;
    public ParticleSystem trail;
    public ParticleSystem emission;
    public GameObject[] searchEnemy;
    public missileLaunch fired;
    float flag = 1;



    // Start is called before the first frame update
    void Start()
    {
        searchEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (searchEnemy.Length < 2)
        {
            target = searchEnemy[0].transform;
        }
        countdown = time;
        rb = GetComponent<Rigidbody2D>();
       
    }
    void search()
    {
        searchEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (searchEnemy.Length < 2)
        {
            target = searchEnemy[0].transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            
            countdown -= Time.deltaTime;
            if (countdown < 0)
            {
                speed = firespeed;
                rotationSpeed = firerotationSpeed;
            }


        if (fired.fired&&flag==1)
        {
            search();
            flag = 0;
        }
        if (fired.fired)
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotationAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotationAmount * rotationSpeed;
            rb.velocity = transform.up * speed;
        }
           
       

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject missileinst = Instantiate(explositionEffect, transform.position, transform.rotation);

            Destroy(gameObject);
            Destroy(missileinst, 2.5f);
        }
    }

}
