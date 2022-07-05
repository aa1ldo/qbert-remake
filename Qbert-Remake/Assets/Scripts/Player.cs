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
            canMove = false;
            StartCoroutine(Move(new Vector2(xPos + 1f, yPos + 1.5f)));
            //xPos += 1f;
            //yPos += 1.5f;
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && canMove)
        {
            canMove = false;
            StartCoroutine(Move(new Vector2(xPos - 1f, yPos + 1.5f)));
            //xPos -= 1f;
            //yPos += 1.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow) && canMove)
        {
            canMove = false;
            StartCoroutine(Move(new Vector2(xPos + 1f, yPos - 1.5f)));
            //xPos += 1f;
            //yPos -= 1.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow) && canMove)
        {
            canMove = false;
            StartCoroutine(Move(new Vector2(xPos - 1f, yPos - 1.5f)));
            //xPos -= 1f;
            //yPos -= 1.5f;
        }

        /*
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            canMove = true;
        }
        */

        /*
        if (!onTile && canMove)
        {
            Debug.Log("Fell off grid...");
            transform.position = new Vector2(0f, 0f);
            GameManager.Instance.LoseLife();
            onTile = true;
        }
        */

        if (outOfBounds)
        {
            StopAllCoroutines();
            transform.position = new Vector2(0f, 0f);
            GameManager.Instance.LoseLife();
            canMove = true;
            outOfBounds = false;
        }
    }

    IEnumerator Move(Vector2 targetPosition)
    {
        //anim.SetTrigger("Jump");
        canMove = false;
        float time = 0f;

        while (time < movementDuration)
        {
            transform.position = Vector2.Lerp(transform.position, targetPosition, time / movementDuration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        canMove = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Tile"))
        {
            onTile = true;
        }

        if (collision.CompareTag("Occupied") && canMove)
        {
            StopAllCoroutines();
            transform.position = new Vector2(0f, 0f);
            GameManager.Instance.LoseLife();
            canMove = true;
        }

        
        if (collision.CompareTag("Enemy"))
        {
            canMove = false;
            StopAllCoroutines();
            transform.position = new Vector2(0f, 0f);
            GameManager.Instance.LoseLife();
            canMove = true;
        }
        
        if (collision.CompareTag("Border"))
        {
            outOfBounds = true;
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
