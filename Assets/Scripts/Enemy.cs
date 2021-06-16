using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private int maxHealth = 100;
	private int currentHealth;
	public GameObject hero;
	public GameObject stone1;
	public GameObject stone2;
	public GameObject stone3;

	private bool bool1;
	private bool bool2;
	private bool bool3;
	private bool m_collided;

	public HealthBar healthBar;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

    private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("OnCollisionEnter2D");
		m_collided = true;
			if (collision.gameObject == stone1) bool1 = true;
			else if (collision.gameObject == stone2) bool2 = true;
			else if (collision.gameObject == stone3) bool3 = true;
	}

    void DestroyGameObject()
	{
		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update()
	{
		if (m_collided)
		{
			if (bool1)
			{
				currentHealth -= 20;
				healthBar.Damage(20);
			}
			else if (bool2)
			{
				currentHealth -= 10;
				healthBar.Damage(10);
			}
			else if (bool3)
			{
				currentHealth -= 35;
				healthBar.Damage(35);
			}
		}

		m_collided = false;

		if (currentHealth < 0)
		{
			DestroyGameObject();
		}
	}
}
