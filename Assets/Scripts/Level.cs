using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static Level instance;

    private int numEnemies = 0;
    private bool startNextLevel = false;
    private float nextLevelTimer = 3;

    public string[] levels = {"Level2C", "Level3C", "Level4C"};
    private int currentLevel = 0;

    private int score = 0;
    public Text scoreText;

    private void Awake()
    {
        instance = this;
        scoreText = GameObject.Find("ScoreValue").GetComponent<Text>();
    }
    
    void Update()
    {
        if (startNextLevel)
        {
            if (nextLevelTimer <=0)
            {
                currentLevel++;
                if (currentLevel <= levels.Length)
                {
                    string sceneName = levels[currentLevel - 1];
                    SceneManager.LoadSceneAsync(sceneName);
                }
                else
                {
                    Debug.Log("Game Over !!!");
                }

                nextLevelTimer = 3;
                startNextLevel = false;
            }
            else
            {
                nextLevelTimer -= Time.deltaTime;
            }
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void AddEnemy()
    {
        numEnemies++;
    }

    public void RemoveEnemy()
    {
        numEnemies--;


        if (numEnemies <= 0)
        {
            startNextLevel = true;
        }
    }
}
