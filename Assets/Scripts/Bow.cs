using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour//script name is Bow and is attached to bow gameelement
{//circle prefab is used to show points
    public Vector2 Direction;
    public float force;
    public GameObject PointPrefab;
    public GameObject[] Points;
    public int numberOfPoints;

    void Start() /*No of points*/
    {
        Points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
        }

    }

    // For mouse positioning
    void Update()

    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos = transform.position;
        Direction = MousePos - bowPos;
        faceMouse();
        for (int i = 0; i < numberOfPoints; i++)
        {
            Points[i].transform.position = PointPosition(i * 0.05f);
        }
    }
    void faceMouse()
    {
        transform.right = Direction;

    }
    Vector2 PointPosition(float t)
    {
        Vector2 currentPointPos = (Vector2)transform.position + (Direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t * t);
        return currentPointPos;
    }
}
