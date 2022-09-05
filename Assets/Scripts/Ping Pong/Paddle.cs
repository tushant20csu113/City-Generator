using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed;
    private Rigidbody2D rb;
    private Vector2 paddleDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        paddleDirection = new Vector2(0, directionY).normalized;
    }
    private void FixedUpdate()
    {

        rb.velocity = paddleDirection * paddleSpeed;
    }
}
