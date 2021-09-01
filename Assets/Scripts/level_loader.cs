using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_loader : MonoBehaviour
{
    public Animator anim;
    public float trans_time = 1f;
    public GameObject MainPlayer;
    public projectilecounter counter;
    int presentScene;

    void Start()
    {
        presentScene = SceneManager.GetActiveScene().buildIndex;
        MainPlayer = GameObject.FindGameObjectWithTag("Target");
    }
    public void loadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void gameover()
    {
        MainPlayer.GetComponent<Player>().SaveCoins();
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
       anim.SetTrigger("start");
       yield return new WaitForSeconds(trans_time);
       SceneManager.LoadScene(levelIndex);
    }
}
