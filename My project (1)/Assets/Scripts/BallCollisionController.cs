using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallCollisionController : MonoBehaviour
{
   public UnityEvent OnBallCollision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("ball hit me");
        OnBallCollision.Invoke();
    }
}
