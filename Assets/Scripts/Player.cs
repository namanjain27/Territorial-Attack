using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{

	public float maxHealth = 100;
	public float currentHealth;

	public GameObject Hit;
	public GameObject slider;
	public GameObject shoot;


	public int enemyCount = 0;

	public int MainEnemy;

	public GameObject hero;
	public GameObject GameOverImage;
	public GameObject NextLevelImage;
	public Enemy enemy;

	public HealthBar healthBar;

	public Triggered trigger;

	public CountdownTimer timer;

	public GameObject healthPotion;
	public bool reached_lever = false;
	public GameObject Pause;
	public AudioSource HitAudio;
	//public AudioSource GameOverAudio;
	public GameObject[] hits_clone;
	public int Hits =0;
	public TextMeshProUGUI Number;
	public bool IsDead = false;
	public AudioSource MainAudio;
	public GameObject GameOverAudio;
	public GameObject GameWinAudio;
	
	Animator m_Animator;
	
	public void Damage(float damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

	public void HealthBoost(float healthIncrease)
    {
		currentHealth += healthIncrease;
		healthPotion.SetActive(false);
		healthBar.SetHealth(currentHealth);
		healthPotion.SetActive(true);
	}

	// Start is called before the first frame update
	void Start()
	{

		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		GameOverImage.SetActive(false);
		NextLevelImage.SetActive(false);
		m_Animator = GetComponent<Animator>();
		hits_clone = GameObject.FindGameObjectsWithTag("Enemy");

	}

	void DestroyEnemy()
	{
		Hit.SetActive(false);
		slider.SetActive(false);
		shoot.SetActive(false);
		Pause.SetActive(false);
		MainAudio.Stop();
		GameWinAudio.GetComponent<AudioSource>().enabled = true;
		gameObject.SetActive(false);
		NextLevelImage.SetActive(true);
		gameObject.GetComponent<Player>().enabled = false;
		trigger.enabled = false;
	}

	public void DestroyObject()
	{
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.GetComponent<AudioSource>().enabled = false;
		MainAudio.Stop();
		GameOverAudio.GetComponent<AudioSource>().enabled = true;
		//GameOverAudio.Play();
		Hit.SetActive(false);
		slider.SetActive(false);
		shoot.SetActive(false);
		for (int k = 0; k < (timer.number) + 1; k++)
		{
			hits_clone[k].SetActive(false);
		}
		GameOverImage.SetActive(true);
		gameObject.GetComponent<Player>().enabled = false;
		Pause.SetActive(false);
		//EndLevel();
	}

	void HitCounter(){
		//TextMeshPro Number = GetComponent<TextMeshPro>();
		Number.text = Hits.ToString();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{	for(int i=0; i<(timer.number)+1; i++ )
		{
			Hits += (int)hits_clone[i].GetComponent<Collided>().HitCount;
			hits_clone[i].GetComponent<Collided>().HitCount = 0;
			if(hits_clone[i].transform.position.x <= -2)
			{
				reached_lever = true;
	        }
		}
		HitCounter();
		bool isHit = false;
        if (trigger.i !=0 && !IsDead)
        {
			isHit = true;
			m_Animator.SetBool("IsHit", isHit);
			HitAudio.Play();
			Damage(trigger.i*10);
			trigger.i = 0;
		}
		if (currentHealth <= 0)
		{
			IsDead = true;
			m_Animator.SetBool("HasDied", IsDead);
			DestroyObject();
		}
		for(int i=0;i<timer.number;i++)
        {
			if (timer.clonedEnemy[i].GetComponent<Enemy>().isDied)
			{
				for ( i = 0; i < timer.number; i++)
                {
					timer.clonedEnemy[i].GetComponent<Enemy>().isDied = false;
				}
				enemy.isDied = false;
					enemyCount += 1;
			}
        }
		if (enemy.isDied)
        {
			enemy.isDied = false;
			enemyCount += 1;
		}
		if (enemyCount == (timer.number + 1)) DestroyEnemy();

		m_Animator.SetBool("IsHit", isHit);
	}
}
