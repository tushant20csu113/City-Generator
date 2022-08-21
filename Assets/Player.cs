using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }
}
