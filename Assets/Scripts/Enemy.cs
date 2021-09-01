using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

	public float maxHealth = 100;
	public float currentHealth;
	public float thundertime=1;
	public bool isHit = false;
	float count;
	public GameObject hero;
	public HealthBar healthBar;
	public Collided collided;
	public AudioSource HitAudio;
	public AudioSource thunder_audio;
	Animator m_Animator;
	public bool isDied = false;
	public float die_time = 2f;
	public GameObject Player;

	public void Damage(float damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
	public void HealthBooster()
	{
		healthBar.SetHealth(maxHealth);
		healthBar.slider.value = 100f;
	}

	public void die_wait(){
		die_time -= Time.deltaTime;
	}

	void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Target");
		count = thundertime;
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		
		m_Animator = GetComponent<Animator>();
	}
	void FixedUpdate()
	{
		if (collided.i != 0 && collided.i!=7)
		{
			isHit = true;
			//m_Animator.SetBool("IsHit", isHit);
			HitAudio.Play();

			Damage(collided.i * 10);
			collided.i = 0;
		}
		if(collided.i==7)
		{
			count -= Time.deltaTime;
			if(count<0)
            {
				thunder_audio.Play();
				Damage(collided.i * 10);
				collided.i = 0;
				count= thundertime;
			}
		}
		if (SceneManager.GetActiveScene().buildIndex ==1)
        {
			if (currentHealth <= 0)
            {
				hero.transform.GetChild(1).gameObject.SetActive(false);
				hero.GetComponent<CapsuleCollider2D>().enabled = false;
				m_Animator.SetBool("HasDied", true);
				die_wait();
				if(die_time<=0)
				{
					isDied = true;
					hero.SetActive(false);
				}
			}

		}
		else if (currentHealth <= 0)
		{
			isHit = false;
			m_Animator.SetBool("IsHit", isHit);
			m_Animator.SetBool("IsWalking", isHit);
			m_Animator.SetBool("HasDied", true);
			hero.GetComponent<EnemyMovement>().enabled = false;
			hero.GetComponent<EnemyShoot>().enabled = false;
			hero.GetComponent<CapsuleCollider2D>().enabled = false;
			hero.transform.GetChild(1).gameObject.SetActive(false);
			
			die_wait();
			if(die_time<=0){
				isDied = true;
				hero.SetActive(false);
			}
			
			collided.i = 0;
		}
	}
}
