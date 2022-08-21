using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotProduct : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    Vector3 direction;
    private float speed = 2f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            direction = player.transform.position - enemy.transform.position;
            Debug.Log("Direction is: " + direction);
            Debug.DrawRay(enemy.transform.position,direction,Color.red);
           
            float range = Vector3.Dot(enemy.transform.forward, direction);
            Debug.DrawRay(enemy.transform.position, enemy.transform.forward*5, Color.blue);
            Debug.Log("Range is: " + range);
            if (range > 0)
            {
                //enemy.transform.LookAt(player.transform);
                enemy.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                //enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, Time.deltaTime * speed);
              
            }
            else
            {
                enemy.transform.GetComponent<MeshRenderer>().material.color = Color.black;
            }
            //enemy.transform.Translate(direction * Time.deltaTime * speed);
        // }

    }
}
