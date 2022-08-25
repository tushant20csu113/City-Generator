using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenZombie : Zombie
{
   
    public GreenZombie(Vector3 GreenZombiePos)
    {

        zombie = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        zombie.transform.position = GreenZombiePos;
        zombie.GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
