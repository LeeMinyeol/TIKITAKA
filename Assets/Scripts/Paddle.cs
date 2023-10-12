using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public Rigidbody2D rigidbody;

    public KeyCode Up;
    public KeyCode Down;

    private float movement;
    private Vector3 startPosition;

    public int playerSize; // 1: Scale 3 / 2: Scale 2.2

    void Start()
    {
        startPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        ApplyMove();  
    }

    public void Reset()
    {
        rigidbody.velocity = Vector3.zero;
        transform.position = startPosition;
    }

    public void ApplyMove()
    {
        if(playerSize == 1)
        {
            if (Input.GetKeyDown(Up))
            {
                if (transform.position.y >= 6f) return;
                rigidbody.MovePosition(rigidbody.position + Vector2.up * 3.2f);
            }
            if (Input.GetKeyDown(Down))
            {
                if (transform.position.y <= -6f) return;
                rigidbody.MovePosition(rigidbody.position + Vector2.down * 3.2f);
            }
        } else
        {
            if (Input.GetKeyDown(Up))
            {
                if (transform.position.y >= 6f) return;
                rigidbody.MovePosition(rigidbody.position + Vector2.up * 2.3f);
            }
            if (Input.GetKeyDown(Down))
            {
                if (transform.position.y <= -6f) return;
                rigidbody.MovePosition(rigidbody.position + Vector2.down * 2.3f);
            }
        }

    }

}
