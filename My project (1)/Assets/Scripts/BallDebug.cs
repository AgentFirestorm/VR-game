using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDebug : MonoBehaviour
{
    Vector3 lastposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cardposition = transform.position;
        Debug.DrawLine(lastposition, cardposition, Color.yellow, 10);
        lastposition = cardposition;
    }
}
