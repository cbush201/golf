using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameManager course;

    void Start()
    {
        course = GameObject.Find("Hotel (Course Control)").GetComponent<GameManager>();
        Debug.Log(course);
    }

    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Trigger Entered");

        if (other.gameObject.name == "GolfBall")
        {
            Debug.Log("Found Golf Ball");
            course.newHole();
        }
    }
}
