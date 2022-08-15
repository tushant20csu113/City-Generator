using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private GameObject human;
    public Human()
    {
        human = GameObject.CreatePrimitive(PrimitiveType.Capsule);
    }
    public virtual void humanColor()
    {            
          human.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
