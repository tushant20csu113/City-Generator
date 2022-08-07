using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityLane 
{
    public float length;
    public float width;
    public Vector3 lanePosition;
    public List<House> houses;

    private Vector3 currentPosition;
    public float occupiedLength;

    public CityLane()
    {
        houses = new List<House>();
        occupiedLength = 0;
        length = 100;
    }
    public void BuildLane()
    {
        House houseToBuild = BuildHouse();
        while(occupiedLength<length)
        {
            if(occupiedLength+houseToBuild.length>length)
            {
                break;
            }
            occupiedLength += houseToBuild.length;
            houses.Add(houseToBuild);
        }
    }
    public House BuildHouse()
    {
        return new House();
    }
}
