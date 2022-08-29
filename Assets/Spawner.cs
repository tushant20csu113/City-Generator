using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner 
{
    GameObject ground;
    public Spawner()
    {
        ground=GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.transform.position = new Vector3();

    }
}
