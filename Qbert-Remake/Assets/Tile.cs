using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    SpriteRenderer tile;

    private void Start()
    {
        tile = GetComponent<SpriteRenderer>();
    }
    public void TileHit()
    {
        if(tile.color == GameManager.Instance.targetColour)
        {
            Debug.Log("Tile is occupied!");
        }
        else
        {
            tile.color = GameManager.Instance.targetColour;
            GameManager.Instance.IncreaseScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TileHit();
        }
    }
}
