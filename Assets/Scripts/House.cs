using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class House 
{
    public int length;
    public Vector3 position;

    public House()
    {
        //Randomises length of houses
        length = Random.Range((int)6, 10);
    }
}
