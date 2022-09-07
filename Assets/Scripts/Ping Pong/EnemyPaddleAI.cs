using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyPaddleAI : MonoBehaviour
{
    public Rigidbody2D ball;
    private Rigidbody2D rb;
    public float racketSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (ball.velocity.x > 0.0f) // Ball moving towards right
        {
            if (ball.position.y > transform.position.y) //Ball is above paddle
            {
                rb.AddForce(Vector2.up * racketSpeed);
            }
            else if (this.ball.position.y < transform.position.y)
            {
                rb.AddForce(Vector2.down * racketSpeed);
            }
        }
        else //Ball moving towards player(left)
        {
            if (transform.position.y > 0.0f) //Paddle above half
            {
                rb.AddForce(Vector2.down * racketSpeed); //Move paddle down
            }
            else if (transform.position.y < 0.0f)
            {
                rb.AddForce(Vector2.up * racketSpeed);
            }
        }
    }

}
