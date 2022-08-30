using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    //Observer pattern
    public delegate void zombieSpawned(Zombie z);
    public event zombieSpawned zombieSpawnEvent;

    List<Zombie> zombies;
    public Zombie zombieObject;
    public int zombieCount;

    //Singleton
    public static ZombieSpawner Instance { get; private set; }
    //MVC
    

    private int playerScore=0;
    [SerializeField] TextMeshProUGUI s_Object;
    private void Awake()
    {
        Instance = this;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        //s_Object.text = "Score: " + playerScore.ToString();
        TextModal.Instance.PlayerScore = playerScore;
        zombies = new List<Zombie>();
        for (int i = 0; i < zombieCount; i++)
        {
            if(i%2==0)
              zombieObject = new Zombie(GetPosition());
            else
              zombieObject = new GreenZombie(GetPosition());
            zombies.Add(zombieObject);
            Spawned(zombieObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Random zombie kill         
            KillZombie();
            if (zombieCount != 0)
            { 
                playerScore += 10;
                TextModal.Instance.PlayerScore = playerScore;
                //s_Object.text = "Score: " + playerScore.ToString();
            }
        }

    }
    private Vector3 GetPosition()
    {
        Vector3 pos = new Vector3(Random.Range(-20f,20f),1f, Random.Range(-20f, 20f));
        return pos;
    }
    public void KillZombie()
    {
        int index = Random.Range((int)0, zombies.Count);
        //Debug.Log("Index " + index);
        zombies[index].KillZombie();
        zombies.RemoveAt(index);

    }
    
    public void Spawned(Zombie z)
    {
        if (zombieSpawnEvent != null)
        {
            zombieSpawnEvent(z);
        }   
    }
}
