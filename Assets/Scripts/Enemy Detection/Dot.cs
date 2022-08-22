using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public GameObject player;
    private Transform enemy;
    Vector3 playerDirection;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.transform;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerDetector();
    }
    private void PlayerDetector()
    {

        playerDirection = player.transform.position - enemy.position;
        //Debug.Log("Direction is: " + playerDirection);
        //Debug.DrawRay(enemy.transform.position, playerDirection, Color.green);

        float range = Vector3.Dot(enemy.transform.forward, playerDirection.normalized);
        //Debug.DrawRay(enemy.transform.position, enemy.transform.forward , Color.blue);
        //Debug.Log("Range is: " + range);
       
              
         float rotationAngle = Mathf.Acos(range / (enemy.transform.forward.magnitude * playerDirection.magnitude))*Mathf.Rad2Deg;
         Debug.Log(rotationAngle);
         enemy.Rotate(new Vector3(0, transform.position.y, 0), rotationAngle);
              
              

        

    }
}
