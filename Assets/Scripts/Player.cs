using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{

	public float maxHealth = 100;
	public float currentHealth;
	public int presentScene;
	public GameObject Hit;
	public GameObject slider;
	public GameObject shoot;
	public GameObject ProjectileButton;

	public int enemyCount;
	public int MainEnemy;

	public GameObject hero;
	public GameObject GameOverImage;
	public GameObject NextLevelImage;
	public Enemy enemy;

	public HealthBar healthBar;

	public Triggered trigger;
	public ParticleSystem crackers;
	public int coins;
	public float timed = 3f; 
	public int enemy_num;
	public int time_ul= 17;
    public int time_ll = 8;
	public float secondsLeft = 0f;
	public bool time_over = true;
	int a=0;
	public GameObject healthPotion;
	public bool reached_lever = false;
	public GameObject Pause;
	public AudioSource HitAudio;
	//public AudioSource GameOverAudio;
	public GameObject[] enemy_order;
	public int Hits =0;
	public TextMeshProUGUI Number;
	public Text enemy_left;
	public bool IsDead = false;
	public AudioSource MainAudio;
	public GameObject GameOverAudio;
	public GameObject GameWinAudio;
	public GameObject MainPlayer;
	private int remainingProjectiles;
	private int LevelScore;
	public bool enemy_shoot = false;
	public bool enemy_walk = true;
	Animator m_Animator;

	float PlayerAnimation=1f;
	
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
		LevelScore = 0;
		coins = PlayerPrefs.GetInt("totalCoins");
		presentScene = SceneManager.GetActiveScene().buildIndex;
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		GameOverImage.SetActive(false);
		NextLevelImage.SetActive(false);
		m_Animator = GetComponent<Animator>();
		//hits_clone = GameObject.FindGameObjectsWithTag("Enemy");
		MainPlayer = GameObject.FindGameObjectWithTag("Target");
		enemyCount = enemy_num;
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
		ProjectileButton.SetActive(false);
		WinLevel();
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
		for (int k = 0; k < enemy_num; k++)
		{
			enemy_order[k].SetActive(false);
		}
		ProjectileButton.SetActive(false);

		if(presentScene >= 6)
		{
		PlayerPrefs.SetInt("RemainingStone", MainPlayer.GetComponent<DisableEnable>().ball - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count1);
		PlayerPrefs.SetInt("RemainingShoe", MainPlayer.GetComponent<DisableEnable>().shoe - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count2);
		PlayerPrefs.SetInt("RemainingBall", MainPlayer.GetComponent<DisableEnable>().stone - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count3);
		PlayerPrefs.Save();
		}
		if(presentScene>=2)
        {
			LevelScore = Hits;
			GameOverImage.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Coins earned -" + LevelScore.ToString();
			coins = coins + (LevelScore);
			PlayerPrefs.SetInt("totalCoins", coins);
			PlayerPrefs.Save();
		}
		GameOverImage.SetActive(true);
		gameObject.GetComponent<Player>().enabled = false;
		Pause.SetActive(false);
	}

	void HitCounter()
	{
		Number.text = Hits.ToString();
		enemy_left.text = enemyCount.ToString();
	}

	IEnumerator Activator(){      //activates the next enemy
		time_over = false;
		enemy_order[a].GetComponent<CapsuleCollider2D>().enabled = true;
		enemy_order[a].GetComponent<EnemyMovement>().enabled = enemy_walk;
		enemy_order[a].GetComponent<EnemyShoot>().enabled = enemy_shoot;
		a++;
		if(a==enemy_num)a=0;
		secondsLeft = Random.Range(time_ll,time_ul);
		yield return new WaitForSeconds(secondsLeft);
		time_over = true;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		coins = PlayerPrefs.GetInt("totalCoins");
		for (int i=0; i<(enemy_num); i++ )
		{
			Hits += (int)enemy_order[i].GetComponent<Collided>().HitCount;
			enemy_order[i].GetComponent<Collided>().HitCount = 0;
			if(enemy_order[i].transform.position.x <= -2)
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
			isHit = false;
			m_Animator.SetBool("IsHit", isHit);
			IsDead = true;
			m_Animator.SetBool("HasDied", IsDead);
			if (PlayerAnimation >= 0) PlayerAnimation -= Time.deltaTime;
			if (PlayerAnimation < 0) DestroyEnemy();
		}

		if(time_over){
			StartCoroutine(Activator());
		}

		for(int i=0;i<enemy_num;i++)
        {
			if (enemy_order[i].GetComponent<Enemy>().isDied)
			{
				for ( i = 0; i < enemy_num; i++)
                {
					enemy_order[i].GetComponent<Enemy>().isDied = false;
				}
				enemy.isDied = false;
					enemyCount -= 1;
			}
        }
		if (enemy.isDied)
        {
			enemy.isDied = false;
			enemyCount -= 1; //counts the enemies left to win that level 
		}
		if (enemyCount == 0) {
			if(timed==3f) crackers.Play();
			//Debug.Log("works");
			if(timed>=0) timed -= Time.deltaTime;
			if(timed < 0) DestroyEnemy();
			
		}
		m_Animator.SetBool("IsHit", isHit);
	}

	public void WinLevel()
    {
		if (presentScene == 1)
		{
			return;
		}
		LevelScore = Hits ;
		if(presentScene>=5) LevelScore += (presentScene-1) * 4; 
		NextLevelImage.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Coins earned -" + LevelScore.ToString();
		coins = coins + (LevelScore);
		PlayerPrefs.SetInt("totalCoins", coins);
		PlayerPrefs.SetInt("levelReached", presentScene);
		PlayerPrefs.Save();

        if(presentScene>=6)
        {
			PlayerPrefs.SetInt("RemainingStone", MainPlayer.GetComponent<DisableEnable>().ball - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count1);
			PlayerPrefs.SetInt("RemainingShoe", MainPlayer.GetComponent<DisableEnable>().shoe - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count2);
			PlayerPrefs.SetInt("RemainingBall", MainPlayer.GetComponent<DisableEnable>().stone - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count3);
			PlayerPrefs.Save();
		}
	}
}
