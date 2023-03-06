using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    private string Name;
    private float power;
    private float lift;

    public Club(string clubName, float x, float y)
    {
        Name = clubName;
        power = x;
        lift = y;
    }

    public float getPower() { return power; }

    public float getLift() { return lift; }

    public string getName() { return Name; }
}
