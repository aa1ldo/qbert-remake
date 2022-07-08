using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    bool lerpToPoint;
    public Vector2 point = new Vector2(0f,0f);
    public float speed;

    private void Update()
    {
        /*
        if (lerpToPoint)
        {
            transform.position = Vector2.LerpUnclamped(transform.position, point, speed);
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //lerpToPoint = true;
        }
    }
}
