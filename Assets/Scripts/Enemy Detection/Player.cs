using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 8f;
    private Vector3 direction;

    //Singleton
    public static Player Instance { get; private set; }



    private Rigidbody m_Rb;
    public Camera followCamera;
    private Vector3 m_CameraPos;

    private int playerHealth=100;
    
    
  
    private void Awake()
    {
        Instance = this;
        m_Rb = GetComponent<Rigidbody>();
        m_CameraPos = followCamera.transform.position - transform.position;
      

    }
    // Start is called before the first frame update
    void Start()
    {
        ZombieSpawner.Instance.zombieSpawnEvent += onZombieSpawn;
        gameObject.transform.GetComponent<MeshRenderer>().material.color = Color.blue; //Player color.
        //m_Object.text = "Health: " + playerHealth.ToString(); //INitial health on screen
        TextModal.Instance.PlayerHealth = playerHealth;
       
    }

    public void onZombieSpawn(Zombie z)
    {
        //whatever Player should do after ZombieSpawn
        Debug.Log("Zombie Spawned at "+z.zombiePosition());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerHealth != 0)
            {
                playerHealth -= 10;
                TextModal.Instance.PlayerHealth = playerHealth;
                //m_Object.text = "Health: " + playerHealth.ToString(); //Updated health depending on space pressed.
            }
            else
            {
                Debug.Log("Player Death");
                Destroy(gameObject);
            }
        }
       
      

    }
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;
       

        if (movement == Vector3.zero)
        {
            
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
