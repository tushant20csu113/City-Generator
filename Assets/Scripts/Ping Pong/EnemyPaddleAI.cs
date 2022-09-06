using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyPaddleAI : MonoBehaviour
{
    public float paddleSpeed;
    private Rigidbody2D rb;
    private Vector2 paddleDirection;

    public float detectionAngle = 90f;
    public float detectionRadius = 90f;
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
        //rb.velocity = paddleDirection * paddleSpeed;
    }
    private void OnDrawGizmos()
    {
        Color c = new Color(0.8f, 0, 0, 0.4f);
        Handles.color = c;
        

        Vector2 rotatedForward = Quaternion.Euler(100, 110, 45) *Vector2.up;
        Handles.DrawSolidArc(transform.position,  new Vector2( transform.position.x,0),-transform.position, detectionAngle, detectionRadius);
        //Handles.DrawWireDisc(transform.position, new Vector3( transform.position.x,0,0),5f);

    }
}
