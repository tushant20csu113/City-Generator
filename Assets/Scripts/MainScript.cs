using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    City Detriot;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Detriot = new City("Detriot", 2,14);
        yield return Detriot.BuildCity();
        yield return Detriot.DestroyCity();

    }

    
}
