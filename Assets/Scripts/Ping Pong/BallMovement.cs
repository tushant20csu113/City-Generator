using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;

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
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        MoveBall(new Vector2(-1, 0));

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
        /*if(collision.gameObject.CompareTag("Player"))
        {
            positionX = 1;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            positionX = -1;
        }*/
        if(collision.gameObject.CompareTag("LeftBorder"))
        {
            ScoreSetter.Instance.IncreaseEnemyScore();
            positionX = 1;
        }
        else if (collision.gameObject.CompareTag("RightBorder"))
        {
            ScoreSetter.Instance.IncreasePlayerScore();
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
