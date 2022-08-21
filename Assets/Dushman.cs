using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dushman : MonoBehaviour
{
    /*float timeCount;
    public float speed = 2f;
    bool change;*/
    public float detectionAngle=10f;
    public float detectionRadius=90f;
    int maxValue = 4; // or whatever you want the max value to be
    int minValue = -4; // or whatever you want the min value to be
    float currentValue = 0; // or wherever you want to start
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentValue += Time.deltaTime * direction; // or however you are incrementing the position
        if (currentValue >= maxValue)
        {
            direction *= -1;
            currentValue = maxValue;
        }
        else if (currentValue <= minValue)
        {
            direction *= -1;
            currentValue = minValue;
        }
        transform.position = new Vector3(currentValue, 1, 0);
        /*timeCount += Time.deltaTime;
        if (timeCount % 2f == 0)
        {
            change = true;
            timeCount = 0;
        }
        else
            change = false;
        if(change==true)
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        else
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
*/
    }
   
    private void OnDrawGizmosSelected()
    {
        Color c = Color.red;
        UnityEditor.Handles.color = c;

        Vector3 rotatedForward = Quaternion.Euler(0, -detectionAngle * 0.5f, 0) * transform.forward;
        UnityEditor.Handles.DrawSolidArc(transform.position, Vector3.up, rotatedForward, detectionAngle, detectionRadius);
        
    }
}
