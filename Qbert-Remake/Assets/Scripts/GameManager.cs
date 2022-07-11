using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public int tilesChanged; // used to calculate when the game should end

    public Color startingColour;
    public Color targetColour;

    public bool gameStart;
    public bool completedLevel;
    public bool continuedToLevel;
    public int currentLevel = 1;

    public GameObject levelSelect;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("No game manager!");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        lives = 3;
        score = 0;
        gameStart = false;
    }

    void Update()
    {
        if(lives < 0)
        {
            lives = 0;
            // Show game over screen
        }

        if(tilesChanged == 28 && !completedLevel)
        {
            score += currentLevel * 1000;
            currentLevel++;
            tilesChanged = 0;
            completedLevel = true;
            levelSelect.SetActive(true);
        }
        else
        {
            completedLevel = false;
        }

        if (levelSelect.activeSelf)
        {
            continuedToLevel = false;
        }
        else
        {
            continuedToLevel = true;
        }
    }

    public void LoseLife()
    {
        lives--;
        // Visual effect happens
    }

    public void IncreaseScore()
    {
        score += 25;
    }
}
