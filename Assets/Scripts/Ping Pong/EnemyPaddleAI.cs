using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleAI : MonoBehaviour
{
    public float paddleSpeed;
    private Rigidbody2D rb;
    private Vector2 paddleDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        paddleDirection = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        //float directionY = Input.GetAxisRaw("Vertical");
       
    }
    private void FixedUpdate()
    {
        rb.velocity = paddleDirection * paddleSpeed;
    }
}
