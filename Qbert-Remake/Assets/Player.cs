using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public Animator anim;
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
        xPos = transform.position.x;
        yPos = transform.position.y;
        //transform.position = new Vector2(xPos, yPos);

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && canMove)
        {
            canMove = false;
            StartCoroutine(Move(new Vector2(xPos + 1f, yPos + 1.5f), 0.5f));
            //xPos += 1f;
            //yPos += 1.5f;
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && canMove)
        {
            canMove = false;
            StartCoroutine(Move(new Vector2(xPos - 1f, yPos + 1.5f), 0.5f));
            //xPos -= 1f;
            //yPos += 1.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow) && canMove)
        {
            canMove = false;
            StartCoroutine(Move(new Vector2(xPos + 1f, yPos - 1.5f), 0.5f));
            //xPos += 1f;
            //yPos -= 1.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow) && canMove)
        {
            canMove = false;
            StartCoroutine(Move(new Vector2(xPos - 1f, yPos - 1.5f), 0.5f));
            //xPos -= 1f;
            //yPos -= 1.5f;
        }

        /*
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            canMove = true;
        }
        */

        if (!onTile)
        {
            GameManager.Instance.LoseLife();
            xPos = 0f;
            yPos = 0f;
            onTile = true;
        }

        if(xPos == 0f && yPos == 0f)
        {
            GameManager.Instance.invincible = true;
        }
        else
        {
            GameManager.Instance.invincible = false;
        }
    }

    IEnumerator Move(Vector2 targetPosition, float duration)
    {
        //anim.SetTrigger("Jump");
        canMove = false;
        float time = 0f;

        while (time < duration)
        {
            transform.position = Vector2.Lerp(transform.position, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Tile"))
        {
            onTile = true;
        }

        if (collision.CompareTag("Enemy"))
        {
            if (!GameManager.Instance.invincible)
            {
                GameManager.Instance.LoseLife();
                xPos = 0f;
                yPos = 0f;
            }
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
