using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int lives;
    int score;

    void Start()
    {
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
