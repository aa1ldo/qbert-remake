using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        // Reset the player's position
    }

    void Update()
    {
        // If 'up arrow' and 'right arrow' pressed
            // Move diagonally
        // If 'up arrow and 'left arrow' pressed
            // Move diagonally
        // If 'down arrow and 'right arrow' pressed
            // Move diagonally
        // If 'down arrow and 'left arrow' pressed
            // Move diagonally

        // If a tile is empty + is hit
            // Call TileHit() from GameManager
            // Call IncreaseScore() from GameManager

        // If an enemy is hit
            // Call LoseLife() from GameManager
    }
}
