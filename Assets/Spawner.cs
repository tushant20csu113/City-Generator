using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner 
{
    GameObject ground;
    public Spawner()
    {
        ground=GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.transform.position = new Vector3();

    }
    public class Player : MonoBehaviour    
    {
           
           
    }     
    public class Enemy : MonoBehaviour 
    { 
        private void Start() 
        {            
                
        }         
        public void onPlayerDeath(Player player)    
        {                         
            //whatever Enemy should do after playerDeath
        }
    }
}
