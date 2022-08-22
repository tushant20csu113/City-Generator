using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dushman : MonoBehaviour
{
    
    public GameObject player;
    private Transform enemy;

    public float detectionAngle=10f;
    public float detectionRadius=90f;
    Vector3 playerDirection;

    int maxValue = 4; // or whatever you want the max value to be
    int minValue = -4; // or whatever you want the min value to be
    float currentValueInX ; // or wherever you want to start
    float currentValueInZ;
    int direction = 1;
    bool detected;
    [SerializeField]
    private float speed = 2f;
    private float rotationAngle;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.transform;
        currentValueInX = gameObject.transform.position.x;
        currentValueInZ = gameObject.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {     
        PlayerDetector();
        Move();

    }
    private void Move()
    {
        if (!detected)
        {
            //Oscillating between maximum and minimum value
            currentValueInX += Time.deltaTime * direction; // or however you are incrementing the position
            if (currentValueInX >= maxValue)
            {
                direction *= -1;
                currentValueInX = maxValue;
            }
            else if (currentValueInX <= minValue)
            {
                direction *= -1;
                currentValueInX = minValue;
            }
            transform.localPosition = new Vector3(currentValueInX, 1f, currentValueInZ);
        }

    }
    private void PlayerDetector()
    {

        playerDirection = player.transform.position - enemy.position;
        //Debug.Log("Direction is: " + playerDirection);
        Debug.DrawRay(enemy.transform.position, playerDirection, Color.green);

        float range = Vector3.Dot( enemy.transform.forward, playerDirection.normalized);
        Debug.DrawRay(enemy.transform.position, enemy.transform.forward * detectionRadius, Color.blue);
        //Debug.Log("Range is: " + range);
        if (playerDirection.magnitude <= detectionRadius)
        {
            if (range > Mathf.Cos(detectionAngle * 0.5f * Mathf.Deg2Rad))
            {
                //enemy.LookAt(player.transform);
                rotationAngle = range / (enemy.transform.forward.magnitude * playerDirection.magnitude);
                Debug.Log(rotationAngle);
                enemy.Rotate(new Vector3(0, transform.position.y, 0), rotationAngle * Mathf.Rad2Deg);
                enemy.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                Debug.Log("Player detected");
                enemy.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, Time.deltaTime * speed);
                detected = true;

            }
            else
            {
                enemy.transform.GetComponent<MeshRenderer>().material.color = Color.black;
                currentValueInX = gameObject.transform.position.x;
                currentValueInZ = gameObject.transform.position.z;
                detected = false;
            }
        }
        else
        {
            enemy.transform.GetComponent<MeshRenderer>().material.color = Color.black;
            currentValueInX = gameObject.transform.position.x;
            currentValueInZ = gameObject.transform.position.z;
            detected = false;
        }

    }

   
    private void OnDrawGizmos()
    {
        Color c = new Color(0.8f,0,0,0.4f);
        UnityEditor.Handles.color = c;

        Vector3 rotatedForward = Quaternion.Euler(0, -detectionAngle * 0.5f, 0) * transform.forward;
        UnityEditor.Handles.DrawSolidArc(transform.position, Vector3.up, rotatedForward, detectionAngle, detectionRadius);
        
    }
}
