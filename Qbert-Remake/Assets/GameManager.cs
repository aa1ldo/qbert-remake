using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Color targetColour;
    public bool invincible;

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
        invincible = true;
        lives = 3;
        score = 0;
    }

    void Update()
    {
        // If all tiles match the specified colour
        // Add 1000 to score
        // Visual effect happens
        // If lives is 0
        // Show game over screen
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
