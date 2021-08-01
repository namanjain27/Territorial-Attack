using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour//script name is Bow and is attached to bow gameelement
{//circle prefab is used to show points
    public Vector2 Direction;
    private float force;

    public GameObject PointPrefab;
    public GameObject[] Points;
    public GameObject extraPoint;
    public GameObject HammerButton;
    public bool changingDirection;
    public float maxY;

    public TouchForce forceAdjust;

    private int arraysize=40;
    public int numberOfPoints = 7;

    public bool tracer=false;

    public Shoot shoot;

    public Vector2 scale;

    public DisableEnable enable;

    public Vector2 MousePos;
    public GameObject HammerSprite;
    public Vector2 Hammer;

    public float presentForce;

    void Start() /*No of points*/
    {
        Points = new GameObject[arraysize];
        for (int i = 0; i < numberOfPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
            Points[i].SetActive(false);
        }

    }

    // For mouse positioning
    void Update()

    {
        if ((enable.active[0] || enable.active[1] || enable.active[2] || HammerButton.activeSelf) && !tracer)
        {
            numberOfPoints = 7;
            for (int i = 0; i < numberOfPoints; i++)
            {
                Points[i].SetActive(true);
            }
        }
        else if ((enable.active[0] || enable.active[1] || enable.active[2] || HammerButton.activeSelf) && tracer)
        {
            for (int i = 0; i < 40; i++)
            {
                Points[i].SetActive(true);
            }
        }
        else
        {
            Inactive();
        }
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos = transform.position;
        Direction = (bowPos - MousePos)/*-scale*/;
        if (HammerSprite.activeSelf || tracer) Direction += Hammer;
        if (enable.active[0] || enable.active[1] || enable.active[2] || HammerButton.activeSelf || tracer)
        {            
            if (Input.GetMouseButton(0))
            {
                if (MousePos.x < 1 /*&& MousePos.y<maxY*/)
                {
                    faceMouse();
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        Points[i].transform.position = PointPosition(i * 0.05f);
                    }
                }
            }
        }
        
    }
    void faceMouse()
    {
        transform.right = Direction;

    }
    Vector2 PointPosition(float t)
    {
        if(shoot.LaunchForce>2000)
        {
            force = (float)((2000-shoot.WindEffect) / 71.5);
        }
        else if(shoot.LaunchForce<200)
        {
            force = (float)((200-shoot.WindEffect) / 71.5);
        }
        else
        {
            force = (float)((shoot.LaunchForce-shoot.WindEffect )/ 71.5);
        }
        
        Vector2 currentPointPos = (Vector2)transform.position + (Direction.normalized * force * t) + 0.5f *Physics2D.gravity* (t * t);
        return currentPointPos;
    }
    public void Tracer()
    {
        tracer = true;
        Inactive();
        for (int i = 0; i < arraysize; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
        }
       numberOfPoints=40;
    }

    public void Inactive()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            Points[i].SetActive(false);
        }
    }
}


