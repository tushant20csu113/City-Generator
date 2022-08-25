using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    List<Zombie> zombies;
    public Zombie zombieObject;
    public int zombieCount;
    // Start is called before the first frame update
    void Start()
    {
        zombies = new List<Zombie>();
        for (int i = 0; i < zombieCount; i++)
        {
            //zombieObject = new Zombie(GetPosition());
            zombieObject = new GreenZombie(GetPosition());
            zombies.Add(zombieObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.A))
        {
            //Random zombie kill
            KillZombie();
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
        Debug.Log("Index " + index);
        zombies[index].KillZombie();
        zombies.RemoveAt(index);

    }
}
