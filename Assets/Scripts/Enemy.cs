using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Human
{
    public Enemy() : base()
    {

    }
    public override void humanColor()
    {
        human.GetComponent<MeshRenderer>().material.color = Color.red;
    }
    public override void Start()
    {
        base.Start();
    }
}
