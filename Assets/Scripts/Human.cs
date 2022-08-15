using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human :MonoBehaviour
{
    public GameObject human;
    public Transform ground;
    protected float xPosition=0f;
    protected float zPosition = 0f;
    public Human()
    {    
        
    }
    public virtual void humanColor()
    {            
          human.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
    public virtual void Start()
    {
        human = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        human.transform.SetParent(ground);
        humanColor();
        float humanHeight = human.transform.GetComponent<MeshFilter>().mesh.bounds.size.y;
        xPosition = Random.Range(-ground.transform.GetComponent<MeshFilter>().mesh.bounds.size.x / 2, ground.transform.GetComponent<MeshFilter>().mesh.bounds.size.x / 2);
        zPosition = Random.Range(-ground.transform.GetComponent<MeshFilter>().mesh.bounds.size.z / 2, ground.transform.GetComponent<MeshFilter>().mesh.bounds.size.z / 2);
        human.transform.localPosition=new Vector3(xPosition,humanHeight/2 , zPosition);

    }

    
    public virtual Transform GetPosition()
    {
        return human.transform;
    }

}
