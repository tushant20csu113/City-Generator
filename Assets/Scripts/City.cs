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
    
    public City(string cityName,int noOfLanes)
    {
        this.cityName = cityName;
        lanes = new CityLane[noOfLanes];
    }
    public void BuildCity()
    {
        for(int i=0;i< lanes.Length;i++)
        {
            lanes[i] = new CityLane();
            lanes[i].BuildLane();
        }
    }
}
