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
    float time = 2f;
    float countdown = 0f;
    public ParticleSystem tailEffect;






    // Start is called before the first frame update
    void Start()
    {
        countdown = time;
        rb = GetComponent<Rigidbody2D>();
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

        tailEffect.Play();


        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotationAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotationAmount * rotationSpeed;
        rb.velocity = transform.up * speed;



    }
    void OnTriggerEnter2D()
    {
        GameObject missileinst = Instantiate(explositionEffect, transform.position, transform.rotation);

        Destroy(gameObject);
        Destroy(missileinst, 2.5f);

    }

}
