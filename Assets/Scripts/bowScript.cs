using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowScript : MonoBehaviour
{
    public Vector2 direction;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (MousePos - transform.position).normalized;
        if(Input.GetButtonDown("Fire3"))  FaceMouse();
    }

    void FaceMouse()
    {
        transform.right = direction;
    }
}
