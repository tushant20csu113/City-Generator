using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : Human
{
    public Police():base()
    {
        humanColor();
    }
    public override void humanColor()
    {
        human.GetComponent<MeshRenderer>().material.color = Color.green;
    }
   
    public override Transform GetPosition()
    {
        return base.GetPosition();
    }

}
