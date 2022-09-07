using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;

    public bool player1Start;

    private int hitCounter = 0;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }
        
    public IEnumerator Launch()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        if (player1Start == true)
            MoveBall(new Vector2(-1, 0));

        else
            MoveBall(new Vector2(1, 0));

    }
    private void RestartBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 1);
    }
    public void MoveBall(Vector2 direction)
    {
        float ballSpeed = startSpeed + hitCounter * extraSpeed;
        rb.velocity = direction.normalized * ballSpeed;
    }
    public void IncreaseHitCounter()
    {
        if(hitCounter*extraSpeed<maxExtraSpeed)
        {
            hitCounter++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 ballPosition = transform.position;
        Vector2 paddlePosition = collision.transform.position;
        float paddleHeight = collision.collider.bounds.size.y;

        float positionX;
        if (collision.gameObject.CompareTag("Player"))
        {
            positionX = 1;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            positionX = -1;
        }
        else if(collision.gameObject.CompareTag("LeftBorder"))
        {
            ScoreSetter.Instance.IncreaseEnemyScore();
            player1Start = true;
            StartCoroutine(Launch());
            positionX = 1;
        }
        else if (collision.gameObject.CompareTag("RightBorder"))
        {
            ScoreSetter.Instance.IncreasePlayerScore();
            player1Start = false; // Start from left
            StartCoroutine(Launch());
            positionX = -1;
        }
        else
        {
            return;
        }
        float positionY = (ballPosition.y - paddlePosition.y) / paddleHeight;
        IncreaseHitCounter();
        MoveBall(new Vector2(positionX, positionY));
    }
}
