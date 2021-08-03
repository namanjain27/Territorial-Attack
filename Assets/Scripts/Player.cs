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
	public GameObject MainPlayer;
	private int remainingProjectiles;
	private int LevelScore;

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
		presentScene = SceneManager.GetActiveScene().buildIndex;
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		GameOverImage.SetActive(false);
		NextLevelImage.SetActive(false);
		m_Animator = GetComponent<Animator>();
		hits_clone = GameObject.FindGameObjectsWithTag("Enemy");
		MainPlayer = GameObject.FindGameObjectWithTag("Target");
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

	public void WinLevel()
    {
		if (presentScene == 1) return;
		remainingProjectiles = MainPlayer.GetComponent<DisableEnable>().ball + MainPlayer.GetComponent<DisableEnable>().shoe + MainPlayer.GetComponent<DisableEnable>().stone - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count1 - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count3 - MainPlayer.transform.GetChild(1).gameObject.GetComponent<Shoot>().count2;
		LevelScore = remainingProjectiles * 100;
		NextLevelImage.transform.GetChild(3).gameObject.GetComponent<Text>().text = "LevelScore-" + LevelScore;
        if (presentScene == 2)
        {
			if (PlayerPrefs.GetInt("highScore1") <= 0)
			{
				PlayerPrefs.SetInt("highScore1", LevelScore);
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore / 100);
				PlayerPrefs.SetInt("totalCoins", coins);
			}
			else if (LevelScore > PlayerPrefs.GetInt("highScore1"))
			{
				int coins = PlayerPrefs.GetInt("totalCoins") + ( LevelScore - PlayerPrefs.GetInt("highScore1"))/100;
				PlayerPrefs.SetInt("highScore1", LevelScore);
				PlayerPrefs.SetInt("totalCoins", coins);
			}
			NextLevelImage.transform.GetChild(4).gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("highScore1").ToString();
		}
		else if (presentScene == 3 )
		{
			if (PlayerPrefs.GetInt("highScore2") <= 0)
			{
				PlayerPrefs.SetInt("highScore2", LevelScore);
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore  / 100);
				PlayerPrefs.SetInt("totalCoins", coins);
			}
			else if (LevelScore > PlayerPrefs.GetInt("highScore2"))
			{
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore - PlayerPrefs.GetInt("highScore2")) / 100;
				PlayerPrefs.SetInt("totalCoins", coins);
				PlayerPrefs.SetInt("highScore2", LevelScore);
			}
			NextLevelImage.transform.GetChild(4).gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("highScore2").ToString();
		}
		else if (presentScene == 4)
		{
			if (PlayerPrefs.GetInt("highScore3") <= 0)
			{
				PlayerPrefs.SetInt("highScore3", LevelScore);
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore  / 100);
				PlayerPrefs.SetInt("totalCoins", coins);
			}
			else if (LevelScore > PlayerPrefs.GetInt("highScore3"))
			{
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore - PlayerPrefs.GetInt("highScore3")) / 100;
				PlayerPrefs.SetInt("totalCoins", coins);
				PlayerPrefs.SetInt("highScore3", LevelScore);
			}
			NextLevelImage.transform.GetChild(4).gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("highScore3").ToString();
		}
		else if (presentScene == 5)
		{
			if (PlayerPrefs.GetInt("highScore4") <= 0)
			{
				PlayerPrefs.SetInt("highScore4", LevelScore);
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore  / 100);
				PlayerPrefs.SetInt("totalCoins", coins);
			}
			else if (LevelScore > PlayerPrefs.GetInt("highScore4"))
			{
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore - PlayerPrefs.GetInt("highScore4")) / 100;
				PlayerPrefs.SetInt("totalCoins", coins);
				PlayerPrefs.SetInt("highScore4", LevelScore);
			}
			NextLevelImage.transform.GetChild(4).gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("highScore4").ToString();
		}
		else if (presentScene == 6)
        {
			if (PlayerPrefs.GetInt("highScore5") <= 0)
			{
				PlayerPrefs.SetInt("highScore5", LevelScore);
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore / 100);
				PlayerPrefs.SetInt("totalCoins", coins);
			}
			else if (LevelScore > PlayerPrefs.GetInt("highScore5"))
			{
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore - PlayerPrefs.GetInt("highScore5")) / 100;
				PlayerPrefs.SetInt("totalCoins", coins);
				PlayerPrefs.SetInt("highScore5", LevelScore);
			}
			NextLevelImage.transform.GetChild(4).gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("highScore5").ToString();
		}
		else if (presentScene == 7)
		{
			if (PlayerPrefs.GetInt("highScore6") <= 0)
			{
				PlayerPrefs.SetInt("highScore6", LevelScore);
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore / 100);
				PlayerPrefs.SetInt("totalCoins", coins);
			}
			else if (LevelScore > PlayerPrefs.GetInt("highScore6"))
			{
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore - PlayerPrefs.GetInt("highScore6")) / 100;
				PlayerPrefs.SetInt("totalCoins", coins);
				PlayerPrefs.SetInt("highScore6", LevelScore);
			}
			NextLevelImage.transform.GetChild(4).gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("highScore6").ToString();
		}
		else if (presentScene == 8) 
		{
			if (PlayerPrefs.GetInt("highScore7") <= 0)
			{
				PlayerPrefs.SetInt("highScore7", LevelScore);
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore / 100);
				PlayerPrefs.SetInt("totalCoins", coins);
			}
			else if (LevelScore > PlayerPrefs.GetInt("highScore7"))
			{
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore - PlayerPrefs.GetInt("highScore7")) / 100;
				PlayerPrefs.SetInt("totalCoins", coins);
				PlayerPrefs.SetInt("highScore7", LevelScore);
			}
			NextLevelImage.transform.GetChild(4).gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("highScore7").ToString();
		}
		/*else if (presentScene == 9)
		{
			if (PlayerPrefs.GetInt("highScore8") <= 0)
			{
				PlayerPrefs.SetInt("highScore8", LevelScore);
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore - PlayerPrefs.GetInt("highScore8")) / 100;
				PlayerPrefs.SetInt("totalCoins", coins);
			}
			else if (LevelScore > PlayerPrefs.GetInt("highScore8"))
			{
				PlayerPrefs.SetInt("highScore8", LevelScore);
				int coins = PlayerPrefs.GetInt("totalCoins") + (LevelScore - PlayerPrefs.GetInt("highScore8")) / 100;
				PlayerPrefs.SetInt("totalCoins", coins);
			}
			NextLevelImage.transform.GetChild(4).gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("highScore8").ToString();
		}*/
		PlayerPrefs.SetInt("levelReached", presentScene);
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
		ProjectileButton.SetActive(false);
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
