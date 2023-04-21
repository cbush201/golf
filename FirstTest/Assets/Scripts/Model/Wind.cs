using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float windSpeed = 5f;
    public Vector3 windDirection = new Vector3(1, 0, 0);

    private GameObject golfBall;
    private BallBehavior ballScript;

    // Start is called before the first frame update
    void Start()
    {
        golfBall = GameObject.Find("GolfBall");
        ballScript = golfBall.GetComponent<BallBehavior>();
    }

    void OnTriggerStay(Collider other)
    {
        if (!ballScript.isGrounded())
        {
            golfBall.GetComponent<Rigidbody>().AddForce(windDirection * windSpeed);
        }  
    }
}
