using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    private Transform target;
    public GameObject golfBall;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (golfBall.GetComponent<Rigidbody>().angularVelocity.magnitude != 0)
        // {
        //     Debug.Log("Not Rotating");
        //     transform.RotateAround(golfBall.transform.position, new Vector3(0, 1, 0), golfBall.GetComponent<BallBehavior>().getRotateSpeed() * Time.deltaTime);
        // }

        
    }
}
