using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityLane 
{
    public float length;
    public float width;
    private int direction;
    public Vector3 lanePosition;
    //public Stack<House> houses;
    public Queue<House> houses;
    GameObject laneObject;

    private Vector3 currentPosition;
    public float occupiedLength;
    private float gap;
    

    public CityLane(Vector3 roadWidth)
    {
        direction = 1;
        //houses = new Stack<House>();
        houses = new Queue<House>();
        occupiedLength = 0;
        laneObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //laneObject.transform.localScale = new Vector3(3, 1,3);
        laneObject.transform.position =roadWidth;
        length = laneObject.GetComponent<MeshFilter>().mesh.bounds.size.z;
        currentPosition = new Vector3(direction*length / 2, 0, -length / 2);
        gap = 0.3f;
    }
    public IEnumerator BuildLane()
    {
        int counter=0;
        
        Debug.Log(occupiedLength);
        while(occupiedLength<length*2)
        {
            yield return new WaitForSeconds(0.3f);
            House houseToBuild = BuildHouse();
            if (occupiedLength+houseToBuild.length>length)
            {
                Debug.Log("House cannot be added.Space not available");
                occupiedLength = 0;
                currentPosition.z = -length / 2;
                currentPosition.x = -length / 2;
                direction = -1;
                counter++;
                if (counter == 2)
                {
                    houseToBuild.Demolish();
                    
                    break;
                }
            }
            //House Construction complete
            occupiedLength += houseToBuild.length+gap;
            PlaceHouse(houseToBuild);
            currentPosition += Vector3.forward * gap;
            //houses.Push(houseToBuild);
            houses.Enqueue(houseToBuild);
            //houseToBuild = BuildHouse();
            //Debug.Log("House added"+ houseToBuild.length+" Total houses "+houses.Count;
        }
    }
    public House BuildHouse()
    {
        return new House(laneObject.transform);
    }
    public IEnumerator DestroyLane()
    {
        foreach (House house in houses)
        {
            yield return new WaitForSeconds(0.3f);
            house.Demolish();
        }
       
    }
    private void PlaceHouse(House house)
    {
        currentPosition += new Vector3(-direction*house.width/2,house.height/2, house.length / 2);
        Debug.Log("New position " + currentPosition);
        house.PlaceAt(currentPosition);
        currentPosition = new Vector3(direction*length / 2, 0, currentPosition.z + house.length / 2);
    }

}
