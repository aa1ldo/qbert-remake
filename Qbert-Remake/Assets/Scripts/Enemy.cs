using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float xPos;
    public float yPos;
    public bool onTile;

    private void Update()
    {
        // transform.position = new Vector2(xPos, yPos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tile"))
        {
            collision.tag = "Occupied";
        }

        if (collision.CompareTag("Occupied"))
        {
            onTile = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Occupied"))
        {
            onTile = false;
            collision.tag = "Tile";
        }
    }
}
