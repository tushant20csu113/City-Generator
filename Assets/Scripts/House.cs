using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class House 
{
    public float length,width,height;
    public Vector3 position { get { return houseObject.transform.position; } }
    private GameObject houseObject;
    private Color[] bColors = { Color.yellow, Color.cyan, Color.black };

    public House(Transform parent)
    {
        
        //Randomises length of houses
        length = Random.Range((int)2, 4);
        width = 4f;
        //Random.Range((int)3, 5);
        height = Random.Range((int)1, 3);
        houseObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        houseObject.transform.SetParent(parent);
        houseObject.transform.localScale = new Vector3(width, height, length);
        houseObject.GetComponent<MeshRenderer>().material.color = bColors[Random.Range((int)0,3)];
       
    }
    public void PlaceAt(Vector3 position)
    {
        houseObject.transform.localPosition = position;
    }
    public void Demolish()
    {
        GameObject.Destroy(houseObject);
    }


}
