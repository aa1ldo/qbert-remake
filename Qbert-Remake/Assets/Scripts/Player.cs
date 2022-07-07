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
    bool outOfBounds;
    bool keepMoving = true;

    bool invincible = false;

    float time = 0f;
    Vector2 targetPosition;
    public float movementDuration;

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
            //StartCoroutine(Move(new Vector2(xPos + 1f, yPos + 1.5f)));
            canMove = false;
            targetPosition = new Vector2(xPos + 1f, yPos + 1.5f);
            //xPos += 1f;
            //yPos += 1.5f;
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && canMove)
        {
            //StartCoroutine(Move(new Vector2(xPos - 1f, yPos + 1.5f)));
            canMove = false;
            targetPosition = new Vector2(xPos - 1f, yPos + 1.5f);
            //xPos -= 1f;
            //yPos += 1.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow) && canMove)
        {
            //StartCoroutine(Move(new Vector2(xPos + 1f, yPos - 1.5f)));
            canMove = false;
            targetPosition = new Vector2(xPos + 1f, yPos - 1.5f);
            //xPos += 1f;
            //yPos -= 1.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow) && canMove)
        {
            //StartCoroutine(Move(new Vector2(xPos - 1f, yPos - 1.5f)));
            canMove = false;
            targetPosition = new Vector2(xPos - 1f, yPos - 1.5f);
            //xPos -= 1f;
            //yPos -= 1.5f;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            canMove = true;
        }

        if (!invincible)
        {
            transform.position = Vector2.Lerp(transform.position, targetPosition, movementDuration);
        }

        /*
        if (!onTile && canMove)
        {
            Debug.Log("Fell off grid...");
            transform.position = new Vector2(0f, 0f);
            GameManager.Instance.LoseLife();
            onTile = true;
        }
        */

        /*
        if (outOfBounds)
        {
            transform.position = new Vector2(0f, 0f);
            GameManager.Instance.LoseLife();
            outOfBounds = false;
        }
        */
    }

    /*
    IEnumerator Move(Vector2 targetPosition)
    {
        //anim.SetTrigger("Jump");
        float time = 0f;

        while (time < movementDuration && keepMoving)
        {
            transform.position = Vector2.Lerp(transform.position, targetPosition, time / movementDuration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
    */

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Tile"))
        {
            onTile = true;
        }

        /*
        if (collision.CompareTag("Occupied"))
        {
            StopAllCoroutines();
            transform.position = new Vector2(0f, 0f);
            GameManager.Instance.LoseLife();
            canMove = true;
        }
        */

        
        if (collision.CompareTag("Enemy"))
        {
            invincible = true;
            transform.position = new Vector2(0f, 0f);
            GameManager.Instance.LoseLife();
        }
        
        if (collision.CompareTag("Border"))
        {
            invincible = true;
            transform.position = new Vector2(0f, 0f);
            GameManager.Instance.LoseLife();
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
