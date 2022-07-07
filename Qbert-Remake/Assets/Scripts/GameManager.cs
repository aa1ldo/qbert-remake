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

    bool completedLevel;

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
            score += 1000;
            // Show win screen
            completedLevel = true;
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
