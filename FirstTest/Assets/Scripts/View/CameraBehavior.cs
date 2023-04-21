using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 CamOffset= new Vector3(-1f, .5f, -3.6f);
    private Transform target;



    void Start()
    {
        target = GameObject.Find("GolfBall").transform;
    }

    void LateUpdate()
    {
        this.transform.position = target.TransformPoint(CamOffset);
        this.transform.LookAt(target, new Vector3(0f, 45f, 0f));
    } 
}
