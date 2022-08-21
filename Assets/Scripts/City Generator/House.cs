using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class House 
{
    public float length,width,height;
    public Vector3 position { get { return houseObject.transform.position; } }
    private GameObject houseObject;
    GameObject human;
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
        humanSpawn();
        //humanSpawn2();
      
    //uman.transform.localScale = new Vector3(0.1f, 1/(height*2), 0.2f);
       
        //float houseHeight = houseObject.GetComponent<MeshFilter>().mesh.bounds.size.y;
        //Debug.Log("house height is " + houseHeight);
        //float humanHeight = human.GetComponent<MeshFilter>().mesh.bounds.size.y;
        //Debug.Log("human position is " + houseHeight * height);

        //man.transform.localPosition = new Vector3(0, houseHeight/2+(humanHeight/2* (1 / (height * 2))), 0f);
        //Debug.Log("Huamn Position " + height / 2 - (1 - (1 / (height * 2))));

    }
    private void humanSpawn2()
    {
        human = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        human.GetComponent<MeshRenderer>().material.color = Color.red;
      //human.transform.localScale = new Vector3(0.1f, 1 / (height * 2), 0.2f);
        float houseHeight = houseObject.GetComponent<MeshFilter>().mesh.bounds.size.y;
        float humanHeight = human.GetComponent<MeshFilter>().mesh.bounds.size.y;
        human.transform.position = new Vector3(0, houseHeight + (humanHeight / 2), 0);
        human.transform.SetParent(houseObject.transform);

    }
    private void humanSpawn()
    {
        human = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        human.GetComponent<MeshRenderer>().material.color = Color.red;
        human.transform.SetParent(houseObject.transform);
        human.transform.localScale = new Vector3(0.1f, 1 / (height * 2), 0.2f);
        float houseHeight = houseObject.GetComponent<MeshFilter>().mesh.bounds.size.y;
        float humanHeight = human.GetComponent<MeshFilter>().mesh.bounds.size.y;
        human.transform.localPosition = new Vector3(0, houseHeight / 2 + (humanHeight / 2 * (1 / (height * 2))), 0f);       
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
