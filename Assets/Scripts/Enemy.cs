using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	Animator m_Animator;
	public bool isDied = false;
	public float die_time = 2f;
	public bool cried = false;
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
		if(die_time<=0) cried = true;
	}

	void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Target");
		count = thundertime;
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		
		m_Animator = GetComponent<Animator>();
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		if (collided.i != 0 && collided.i!=7)
		{
			isHit = true;
			m_Animator.SetBool("IsHit", isHit);
			HitAudio.Play();

			Damage(collided.i * 10);
			collided.i = 0;
		}
		if(collided.i==7)
		{
			count -= Time.deltaTime;
			if(count<0)
            {
				isHit = true;
				m_Animator.SetBool("IsHit", isHit);
				HitAudio.Play();

				Damage(collided.i * 10);
				collided.i = 0;
				count= thundertime;
			}
		}
		if (currentHealth <= 0)
		{
			if(Player.GetComponent<Player>().enemyCount==1)
            {
				Player.GetComponent<Triggered>().enabled = false;
            }
			isHit = false;
			m_Animator.SetBool("IsHit", isHit);
			m_Animator.SetBool("IsWalking", isHit);
			m_Animator.SetBool("HasDied", true);
			hero.GetComponent<EnemyMovement>().enabled = false;
			hero.GetComponent<EnemyShoot>().enabled = false;
			hero.GetComponent<CapsuleCollider2D>().enabled = false;
			
			die_wait();
			if(cried){
				isDied = true;
			//m_Animator.SetBool("HasDied", isDied);
				hero.SetActive(false);
				cried = false;
				hero.GetComponent<EnemyMovement>().enabled = true;
				hero.GetComponent<EnemyShoot>().enabled = true;
				hero.GetComponent<CapsuleCollider2D>().enabled = true;
			}
			
			collided.i = 0;
		}
		m_Animator.SetBool("IsHit", isHit);
	}
}
