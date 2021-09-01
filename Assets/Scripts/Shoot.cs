using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Bow bow;
    public GameObject Stone1;
    public GameObject Stone2;
    public GameObject Stone3;

    public int count=0;
    float t1, t2;
    float actual_difference;
    public float Time_Difference=0;
    public float decreaseForce=300f;

    public float WindEffect;

    public GameObject Ground;

    public int count1 = 0;
    public int count2 = 0;
    public int count3 = 0;

    public DisableEnable enable;

    public GameObject HammerSprite;
    public GameObject HammerButton;
    public GameObject Hammer;
    public GameObject hero;
    public GameObject tracer;

    public GameObject healthPotion;
    public GameObject Shield;

    public GameObject shoot;
    public bool pressed_shoot = false;
    public float LaunchForce;
    public Slider force;

    public bool shot = false;

    Animator m_Animator;

    float Time_Passed=0f;

    private void Start()
    {
        m_Animator = GameObject.Find("Player").GetComponent<Animator>();
        Ground = GameObject.FindGameObjectWithTag("Ground");
    }
    // Update is called once per frame
    /*public void AdjustForce(float newforce)
    {
        LaunchForce = newforce;
    }*/

    public void shoot_press(){
        if (enable.active[0] || enable.active[1] || enable.active[2] || HammerSprite.activeSelf)
        {
            if(count==0)
            {
                t1 = Time_Passed;
                count = 1;
            }
            else if(count==1)
            {
                t2 = Time_Passed;
                count = 0;
            }
            pressed_shoot = true;
        }       
    }

    void Update()
    {
        if (LaunchForce > 2000) LaunchForce = 2000f;
        else if (LaunchForce < 200) LaunchForce = 200f;
        if (t1 > t2) actual_difference = t1 - t2;
        else if (t2 > t1) actual_difference = t2 - t1;
        Time_Passed += Time.deltaTime;
        if (pressed_shoot)
        {
            shot = true;
            if (GameObject.Find("Player").GetComponent<DisableEnable>().active[0])
            {
                count1 += 1;
                Shooting(Stone1);

            }
            else if (GameObject.Find("Player").GetComponent<DisableEnable>().active[1])
            {
                count2 += 1;
                Shooting(Stone2);
            }

            else if (GameObject.Find("Player").GetComponent<DisableEnable>().active[2])
            {
                count3 += 1;
                Shooting(Stone3);
            }
            else if (HammerSprite.activeSelf) Shooting(Hammer);
        }
    }

    void Shooting(GameObject other)
    {
        m_Animator.SetBool("HasShot", shot);
        if (actual_difference<Time_Difference)
        {
            LaunchForce -= decreaseForce;
            if (LaunchForce <= 0) LaunchForce = 0;
            force.value = LaunchForce;
        }
        if (other.gameObject == Hammer)
        {
            GameObject Stoneclone = Instantiate(other, HammerSprite.transform.position, HammerSprite.transform.rotation);
            Stoneclone.GetComponent<Rotation>().rotation = true;
            Stoneclone.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            float range = WindEffect;
            float random = Random.Range(0, 1);
            if (random < 0.5) WindEffect = (WindEffect / 2);
            else WindEffect = (WindEffect * 2);
            if(LaunchForce>2000)
            {
                Stoneclone.GetComponent<Rigidbody2D>().AddForce(transform.right * (2000 - WindEffect));
            }
            else
            {
                Stoneclone.GetComponent<Rigidbody2D>().AddForce(transform.right * (LaunchForce - WindEffect));
            }            
        }
        else
        {
            //HammerButton.GetComponent<AudioSource>().enabled = false;
            GameObject Stoneclone = Instantiate(other, transform.position, transform.rotation);
            Stoneclone.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            if (LaunchForce > 2000)
            {
                Stoneclone.GetComponent<Rigidbody2D>().AddForce(transform.right * (2000 - WindEffect));
            }
            else
            {
                Stoneclone.GetComponent<Rigidbody2D>().AddForce(transform.right * (LaunchForce - WindEffect));
            }
        }
        //HammerButton.GetComponent<AudioSource>().volume = 0f;
        healthPotion.GetComponent<AudioSource>().volume = 0f;
        Shield.GetComponent<AudioSource>().volume = 0f;
        HammerSprite.SetActive(false);
        if(bow.tracer)
        {
            bow.Inactive();
            bow.tracer = false;
        }
        shot = false;
        m_Animator.SetBool("HasShot", shot);
        pressed_shoot = false;
        shoot.SetActive(false);
        shoot.SetActive(true);
        tracer.SetActive(false);
        tracer.SetActive(true);
        LaunchForce = 0;
        force.value = LaunchForce;
    }
}