using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 8f;
    private Vector3 direction;
    public static Player Instance { get; private set; }
    private Rigidbody m_Rb;
    public Camera followCamera;
    private Vector3 m_CameraPos;
    private void Awake()
    {
        Instance = this;
        m_Rb = GetComponent<Rigidbody>();
        m_CameraPos = followCamera.transform.position - transform.position;

    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetComponent<MeshRenderer>().material.color = Color.blue;
       

    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = -Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
        }
        gameObject.transform.Translate(direction * speed * Time.deltaTime);
      

    }*/
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;
        m_Rb.useGravity = true;

        if (movement == Vector3.zero)
        {
            m_Rb.useGravity = false;
            m_Rb.velocity = Vector3.zero;
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(movement);

        targetRotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            360 * Time.fixedDeltaTime);

        m_Rb.MovePosition(m_Rb.position + movement * speed * Time.fixedDeltaTime);
        m_Rb.MoveRotation(targetRotation);
    }
    private void LateUpdate()
    {
        followCamera.transform.position = m_Rb.position + m_CameraPos;
    }
}
