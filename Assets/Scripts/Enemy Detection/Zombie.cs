using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie
{
    //zombieHealth
    int zombieHealth = 100;
    //RangeOfAttack
    float attackRange;
    protected GameObject zombie;
    // Start is called before the first frame update
    public Zombie(Vector3 zombiePos)
    {
        zombie = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        zombie.transform.position = zombiePos;
        zombie.GetComponent<MeshRenderer>().material.color = Color.red;
        PlayerDetector();

    }
    public Zombie()
     {}
    public Vector3 zombiePosition()
    {
        return zombie.transform.position;

    }



    void PlayerDetector()
    {

    }
    public void KillZombie()
    {
        GameObject.Destroy(zombie);
    }
}
