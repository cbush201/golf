using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBag : MonoBehaviour
{
    [SerializeField] private (string Name, float Power, float Lift)[] clubs;
    private int currentClub;
    [SerializeField] private ClubText clubtext;

    [Header("Clubs and Values")]
    [SerializeField] private (string Name, float Power, float Lift) driver = ("Driver", 50f, 30f);
    [SerializeField] private (string Name, float Power, float Lift) wood   = ("Wood", 40f, 32f  );
    [SerializeField] private (string Name, float Power, float Lift) iron_3 = ("3 Iron", 35f, 35f);
    [SerializeField] private (string Name, float Power, float Lift) iron_5 = ("5 Iron", 30f, 30f);
    [SerializeField] private (string Name, float Power, float Lift) iron_7 = ("7 Iron", 25f, 25f);
    [SerializeField] private (string Name, float Power, float Lift) iron_9 = ("9 Iron", 22f, 22f);
    [SerializeField] private (string Name, float Power, float Lift) wedge  = ("Wedge", 18f, 10f  );
    [SerializeField] private (string Name, float Power, float Lift) putter = ("Putter", 15f, 0f );
    
    void Start() 
    {
        clubs = new (string Name, float Power, float Lift)[8] { driver, wood, iron_3, iron_5, iron_7, iron_9, wedge, putter };
        clubtext = GameObject.Find("ClubText").GetComponent<ClubText>();
        clubtext.clubname = clubs[currentClub].Name;
        currentClub = 0;
    }

    public (string Name, float Power, float Lift) moveClub(int direction)
    {
        if (direction > 0)
        {
            if (currentClub + direction < clubs.Length) 
            { 
                currentClub += direction; 
            }
        }
        if (direction < 0)
        {
            if (currentClub + direction >= 0) 
            { 
                currentClub += direction; 
            }
        }

        clubtext.clubname = clubs[currentClub].Name;
        return clubs[currentClub];
    }

    public (string Name, float Power, float Lift) getClub()
    {
        return clubs[currentClub];
    }
}
