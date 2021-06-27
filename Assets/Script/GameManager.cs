using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameover = false;
    public Text scoreText;
    public GameObject gameOverUI;

    private int score = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("게임메니저 두개 이상 존재");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameover == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
    public void AddScrore(int newScore)
    {
        if(!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }

    }
    public void OnPlayerDead()
    {
        isGameover = true;
        gameOverUI.SetActive(true);
    }
}
