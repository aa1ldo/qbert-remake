using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xPos;
    float yPos;

    bool canMove;
    bool onTile;

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

        if (!onTile)
        {
            GameManager.Instance.LoseLife();
            xPos = 0f;
            yPos = 0f;
            onTile = true;
        }

        if(xPos == 0f && yPos == 0f)
        {
            GameManager.Instance.spawning = false;
        }
        else
        {
            GameManager.Instance.spawning = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Tile"))
        {
            onTile = true;
        }

        if (collision.CompareTag("Enemy"))
        {
            GameManager.Instance.LoseLife();
            xPos = 0f;
            yPos = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tile"))
        {
            onTile = false;
        }
    }
}
