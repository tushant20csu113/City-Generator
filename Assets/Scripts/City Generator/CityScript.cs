using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScript : MonoBehaviour
{
    public GameObject[] buildings;
    public Transform ground;
    public float mapWidth ;
    public float mapHeight ;
    public int laneWidth=5;
    public float roadWidth;
    // Start is called before the first frame update
    /*
     * position=oldPosition+new Vector(BuildingWidth,0,0);
     * if(position.x<laneWidth)
     * {
     *  GameObject g=Instantiate(buildings[n], position, Quaternion.identity);
     *  oldPosition=position;
     *  Direction
        g.transform.Rotate(0, 180f, 0);
       }
       else
       
     */
    void Start()
    {
        Vector3 size = ground.GetComponent<Renderer>().bounds.size;
        mapHeight = size.x;
        mapWidth = size.z;
        //Lane 1
        for (int h=0;h<4;h++)
        {
            for (int w = 0; w < laneWidth; w++)
            {
                if (h < 2)
                {
                    int n = Random.Range(0, buildings.Length);
                    Vector3 pos = new Vector3(w*1.4f , 0, h*1.4f );                  
                    GameObject g=Instantiate(buildings[0], pos, Quaternion.identity);
                    g.transform.Rotate(0, 180f, 0);
                }
                else
                {
                    
                    int n = Random.Range(0, buildings.Length);
                    Vector3 pos = new Vector3((w*1.4f), 0, (h*1.4f)  + roadWidth);
                    Instantiate(buildings[0], pos, Quaternion.identity);

                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
