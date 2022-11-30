using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] 
    List<Transform> waypoints;

    [SerializeField]
    float carSpeed = 2f;

    [SerializeField]
    float rotationSpeed = 2f;

    int waypointIndex = 0;

    private void Start()
    {
        transform.position = waypoints[waypointIndex].position; // Starting enemycar position = 1st waypoint.
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; //Start point in the scene
        Gizmos.DrawSphere(waypoints[0].position, 0.5f);

        Gizmos.color = Color.green;
        for (int i = 1; i < waypoints.Count; i++)
        {
            Gizmos.DrawSphere(waypoints[i].position, 0.5f);
        }

        Gizmos.color = Color.blue;
        for (int i = 1; i < waypoints.Count; i++)
        {
            Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);
        }

        Gizmos.color = Color.red; // Finish Point in the scene
        Gizmos.DrawSphere(waypoints[waypoints.Count - 1].position, 0.5f);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].position;
            var move = carSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, move);
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(waypoints[waypointIndex].position - transform.position);
            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationSpeed);

            if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
            {
                waypointIndex++;
            }
        }
        else
            waypointIndex = 0;
    }
}
