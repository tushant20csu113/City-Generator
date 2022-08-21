using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
       
        yield return City.Instance.BuildCity("Detriot", 4, 14);
        //yield return Detriot.DestroyCity();

    }

    
}
