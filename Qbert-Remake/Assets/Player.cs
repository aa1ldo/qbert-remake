using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xPos;
    float yPos;

    bool canMove;

    void Start()
    {
        xPos = 0f;
        yPos = 0f;
        canMove = true;
    }

    void Update()
    {
        transform.position = new Vector2(xPos, yPos);

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && canMove)
        {
            canMove = false;
            xPos += 1f;
            yPos += 1.5f;
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && canMove)
        {
            canMove = false;
            xPos -= 1f;
            yPos += 1.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow) && canMove)
        {
            canMove = false;
            xPos += 1f;
            yPos -= 1.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow) && canMove)
        {
            canMove = false;
            xPos -= 1f;
            yPos -= 1.5f;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            canMove = true;
        }

        // If a tile exists and is empty + is hit
            // Call TileHit() from GameManager
            // Call IncreaseScore() from GameManager
        // If there is not a tile
            // Call LoseLife() from GameManager

        // If an enemy is hit
        // Call LoseLife() from GameManager
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Tile")
        {
            // Call TileHit()
            // Call IncreaseScore()
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tile")
        {
            Debug.Log("Lose 1 life");
        }
    }
}
