using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public float firstSpeed = 5f;
    public float speedIncrease = 0.2f; // 설정에서 변경할 수 있게 할것임, 패들에 맞을때마다 증가되는 속도
    public Rigidbody2D rigidbody;
    public Vector3 prePosition;

    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        prePosition = transform.position;
        speed = firstSpeed;
        Launch();
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rigidbody.velocity = new Vector2(x, y).normalized * speed;
    }

    public void Reset()
    {
        rigidbody.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        speed = firstSpeed;
        Launch();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Wall"))
        {
            prePosition = transform.position;

        }

        if (collision.transform.CompareTag("Player"))
        {

            if (collision.transform.GetComponent<Paddle>().isPlayer1)
            {
                float randomAngle = Random.Range(-50f, 50f);
                Vector2 direction = Quaternion.Euler(0f, 0f, randomAngle) * Vector2.right;
                rigidbody.velocity = direction.normalized * speed;
            }
            else
            {
                float randomAngle = Random.Range(-50f, 50f);
                Vector2 direction = Quaternion.Euler(0f, 0f, randomAngle) * Vector2.left;
                rigidbody.velocity = direction.normalized * speed;
            }
            prePosition = transform.position;
            speed += speedIncrease;
        }
        

    }

    
}
