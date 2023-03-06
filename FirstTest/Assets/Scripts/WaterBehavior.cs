using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "GolfBall")
        {
            other.gameObject.GetComponent<BallBehavior>().setPos(other.gameObject.GetComponent<BallBehavior>().getStartPos());
        }
    }
}