using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBag : MonoBehaviour
{
    private Club[] clubs;
    private int currentClub;

    public GolfBag() 
    {
        clubs = new Club[3] { new Club("Driver", 25, 20), new Club("Iron", 18, 22), new Club("Putter", 10, 0) };
        currentClub = 0;
    }

    public Club moveUpClub()
    {
        if (clubs[currentClub].getName() != "Driver")
        {
            currentClub -= 1;
        }
        return clubs[currentClub];
    }

    public Club moveDownClub()
    {
        if (clubs[currentClub].getName() != "Putter")
        {
            currentClub += 1;
        }
        return clubs[currentClub];
    }

    public Club getClub()
    {
        return clubs[currentClub];
    }
}
