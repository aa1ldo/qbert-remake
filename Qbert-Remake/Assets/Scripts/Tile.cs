using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    SpriteRenderer tile;

    public bool firstTile;

    /*
    Color[] colours = { new Color(255, 0, 0, 255), new Color(0, 255, 0, 255), new Color(0, 0, 255, 255) };
    Color currentColour;
    int index = 0;
    */

    private void Start()
    {
        tile = GetComponentInChildren<SpriteRenderer>();
        tile.color = GameManager.Instance.startingColour;
    }

    private void Update()
    {
        /*
        if (GameManager.Instance.completedLevel)
        {
            if (index < 2)
            {
                currentColour = colours[index];
                tile.color = currentColour;
                index++;
            }
            else
            {
                index = 0;
            }
        }
        */

        if (GameManager.Instance.completedLevel)
        {
            tile.color = GameManager.Instance.startingColour;

            if(firstTile)
                gameObject.tag = "FirstTile";
        }
    }

    public void TileHit()
    {
        if(tile.color != GameManager.Instance.targetColour)
        {
            tile.color = GameManager.Instance.targetColour;
            GameManager.Instance.IncreaseScore();
            GameManager.Instance.tilesChanged++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.tag == "Tile")
        {
            TileHit();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.CompareTag("FirstTile") && firstTile)
        {
            gameObject.tag = "Tile";
        }
    }
}
