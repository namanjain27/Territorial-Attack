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
	// Start is called before the first frame update
	void Start()
	{
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
			isDied = true;
			m_Animator.SetBool("HasDied", isDied);
			hero.SetActive(false);
		}
		m_Animator.SetBool("IsHit", isHit);
	}
}
