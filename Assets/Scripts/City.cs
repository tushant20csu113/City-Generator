using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Conatins lanes,roadsand houses
/// </summary>
public class City 
{
    public CityLane[] lanes;
    private string cityName;
    float roadWidth=0;
    
    public City(string cityName,int noOfLanes,float roadWidth)
    {
        this.cityName = cityName;
        lanes = new CityLane[noOfLanes];
        this.roadWidth = roadWidth;
        
    }
    public IEnumerator BuildCity()
    {
        for(int i=0;i< lanes.Length;i++)
        {
            lanes[i] = new CityLane(GetLanePosition(i));
            yield return lanes[i].BuildLane();
            //roadWidth = new Vector3(5f,0,0);
        }
    }
    private Vector3 GetLanePosition(int i) // i = 0, 2, 4 -> 0, 10, 20 or i = 1, 3, 5 -> 0, 10, 20. 
    {
        //For horizontal:
        if (i % 2 != 0)//odd
            return new Vector3(-(i - 1) / 2 * 10 - roadWidth / 2*(i/2), 0, 0);
        else//even
            return new Vector3((i / 2) * 10 + roadWidth / 2*(i/2), 0, 0);
        /*//For vertical:
        if (i % 2 != 0)
            return new Vector3( -roadWidth / 2, 0, (i - 1) / 2 * 10);
        else
            return new Vector3( +roadWidth / 2, 0, (i / 2) * 10);*/


    }
}
