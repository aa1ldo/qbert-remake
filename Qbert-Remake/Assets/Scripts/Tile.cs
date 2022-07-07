using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    SpriteRenderer tile;

    private void Start()
    {
        tile = GetComponentInChildren<SpriteRenderer>();
        tile.color = GameManager.Instance.startingColour;
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
        if (collision.CompareTag("Player") && gameObject.tag == "FirstTile")
        {
            gameObject.tag = "Tile";
        }
    }
}
